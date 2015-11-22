using System;
using UnityEngine;

public class Turkey_WalkState : I_ActorState
{
    static float maxSpeed = 0.1f;

    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Turkey entered walk state");
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Turkey exited walk state");
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
            return new Turkey_PunchState();
        }
        else if (!Input.GetKey(ac.LEFT) && !Input.GetKey(ac.RIGHT))
        {
            return new Turkey_IdleState();
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
            moveDir.x = -maxSpeed;
        }
        else if (Input.GetKey(ac.RIGHT))
        {
            moveDir.x = maxSpeed;
        }

        actor.GetComponent<Animator>().SetFloat("MoveSpeed", Math.Abs(moveDir.x));

        if (actor.transform.localPosition.x > GameObject.FindGameObjectWithTag("Santa").GetComponent<Transform>().localPosition.x)
            actor.localScale = leftFace;
        else
            actor.localScale = rightFace;

        trans.Translate(moveDir);
    }
}
