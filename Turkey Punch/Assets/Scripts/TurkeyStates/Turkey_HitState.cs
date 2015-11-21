using System;
using UnityEngine;

public class Turkey_HitState : I_ActorState
{
    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Turkey entered hit state");
        actor.GetComponentInChildren<ParticleSystem>().Play();
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Turkey exited hit state");
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        return new Turkey_IdleState();
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
