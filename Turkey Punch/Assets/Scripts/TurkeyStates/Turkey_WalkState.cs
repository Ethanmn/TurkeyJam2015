using System;
using UnityEngine;

public class Turkey_WalkState : I_ActorState
{
    KeyCode left = KeyCode.J;
    KeyCode right = KeyCode.L;

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
        if (Input.GetMouseButtonDown(0))
        {
            return new Turkey_HitState();
        }
        else if (!Input.GetKey(left) && !Input.GetKey(right))
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
        Transform trans = actor.GetComponent<Transform>();
        Vector3 moveDir = new Vector3();

        if (Input.GetKey(left))
        {
            moveDir.x = -0.1f;
            actor.localScale = new Vector3(-1, 1);
        }
        else if (Input.GetKey(right))
        {
            moveDir.x = 0.1f;
            actor.localScale = new Vector3(1, 1);
        }

        actor.GetComponent<Animator>().SetFloat("MoveSpeed", Math.Abs(moveDir.x));

        trans.Translate(moveDir);
    }
}
