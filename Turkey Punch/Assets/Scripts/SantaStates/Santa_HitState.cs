using System;
using UnityEngine;

public class Santa_HitState : I_ActorState
{
    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Santa entered hit state");
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Santa exited hit state");
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        return new Santa_IdleState();
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
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
