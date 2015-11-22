using System;
using UnityEngine;

public class Santa_WalkState : I_ActorState
{
    static float maxSpeed = 0.1f;

    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Santa entered walk state");
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Santa exited walk state");
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        ActorController ac = actor.GetComponent<ActorController>();

        if (Input.GetKeyDown(ac.ATTACK1))
        {
            return new Santa_PunchState();
        }
        else if (!Input.GetKey(ac.LEFT) && !Input.GetKey(ac.RIGHT))
        {
            return new Santa_IdleState();
        }
        else
        {
            Move(actor);
            return null;
        }
    }

    I_ActorState I_ActorState.OnCollisionEnter(Transform actor, Collision2D c)
    {
        return null;
    }

    I_ActorState I_ActorState.OnCollisionStay(Transform actor, Collision2D c)
    {
        return null;
    }

    void Move(Transform actor)
    {
        ActorController ac = actor.GetComponent<ActorController>();
        Transform trans = actor.GetComponent<Transform>();

        Vector3 moveDir = new Vector3();

        Vector3 leftFace = new Vector3(-1, 1);
        Vector3 rightFace = new Vector3(1, 1);

        if (Input.GetKey(ac.LEFT))
        {
            // Direction is move left 

            moveDir.x = -maxSpeed;
        }
        else if (Input.GetKey(ac.SPECIAL))
        {
            if (actor.GetComponent<ActorStats>().SpecialCharge >= 50)
                return new Santa_SpecialState();
        }
        else if (Input.GetKey(ac.RIGHT))
        {
            // Direction is move right

            moveDir.x = maxSpeed;
        }
        actor.GetComponent<Animator>().SetFloat("MoveSpeed", Math.Abs(moveDir.x));

        if (actor.transform.localPosition.x > GameObject.FindGameObjectWithTag("Turkey").GetComponent<Transform>().localPosition.x)
            actor.localScale = leftFace;
        else
            actor.localScale = rightFace;

        float verticalSize = Camera.main.orthographicSize * 2.0f;
        float horizontalSize = verticalSize * Screen.width / Screen.height;

        if (trans.position.x + moveDir.x < -horizontalSize /2)
        {
            trans.position = trans.position = new Vector3(-horizontalSize / 2, trans.position.y, trans.position.z);
        }
        else if (trans.position.x + moveDir.x > horizontalSize / 2)
        {
            trans.position = trans.position = new Vector3(horizontalSize / 2, trans.position.y, trans.position.z);
        }
        else
        {
            trans.Translate(moveDir);
        }
    }
}
