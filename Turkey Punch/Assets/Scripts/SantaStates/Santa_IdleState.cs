using System;
using UnityEngine;

public class Santa_IdleState : I_ActorState
{
    private Animator santaAnim;

    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Santa entered idle state");

        actor.GetComponent<Animator>().SetFloat("MoveSpeed", 0);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Santa exited idle state");
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
            return new Santa_HitState();
        }

        if (Input.GetKeyDown(ac.LEFT) || Input.GetKeyDown(ac.RIGHT))
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
