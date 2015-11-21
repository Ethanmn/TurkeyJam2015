using System;
using UnityEngine;

public class Santa_IdleState : I_ActorState
{
    private Animator santaAnim;

    void I_ActorState.OnEnter(Transform actor)
    {
        actor.GetComponent<Animator>().SetFloat("MoveSpeed", 0);
    }

    void I_ActorState.OnExit(Transform actor)
    {
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        if (Input.GetKey(KeyCode.F))
        {
            return new Santa_PunchState();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            return new Santa_WalkState();
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
