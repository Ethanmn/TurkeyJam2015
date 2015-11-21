using System;
using UnityEngine;

public class Santa_PunchState : I_ActorState
{
    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Santa entered punch state");
        SpriteRenderer sr = actor.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.b, sr.color.r, sr.color.g, (sr.color.a > 0) ? 0 : 1);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Santa exited punch state");
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
