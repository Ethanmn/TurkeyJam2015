using System;
using UnityEngine;

public class Turkey_IdleState : I_ActorState
{
    private Animator santaAnim;

    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Turkey entered idle state");

        actor.GetComponent<Animator>().SetFloat("MoveSpeed", 0);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Turkey exited idle state");
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        if (Input.GetMouseButton(0))
        {
            return new Turkey_HitState();
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
        {
            return new Turkey_WalkState();
        }

        return null;
    }

    I_ActorState I_ActorState.OnCollisionEnter(Transform actor, Collision2D c)
    {
        return null;
    }

    I_ActorState I_ActorState.OnCollisionStay(Transform actor, Collision2D c)
    {
        return null;
    }
}
