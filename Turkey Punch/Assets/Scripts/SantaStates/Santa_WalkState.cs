using System;
using UnityEngine;

public class Santa_WalkState : I_ActorState
{
    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Santa entered walk state");
        //actor.GetComponent<Transform>().localScale = new Vector3(3, 3);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Santa exited walk state");
        //actor.GetComponent<Transform>().localScale = new Vector3(1, 1);
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        if (Input.GetMouseButtonDown(0))
        {
            return new Santa_PunchState();
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
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
        Transform trans = actor.GetComponent<Transform>();
        Vector3 moveDir = new Vector3();

        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -0.1f;
            actor.localScale = new Vector3(-1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 0.1f;
            actor.localScale = new Vector3(1, 1);
        }

        actor.GetComponent<Animator>().SetFloat("MoveSpeed", Math.Abs(moveDir.x));

        trans.Translate(moveDir);
    }
}
