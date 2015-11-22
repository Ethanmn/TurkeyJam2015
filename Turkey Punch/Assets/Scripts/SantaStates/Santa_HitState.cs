using System;
using UnityEngine;

public class Santa_HitState : I_ActorState
{
    float timer = 0;

    void I_ActorState.OnEnter(Transform actor)
    {
        actor.GetComponent<Animator>().SetBool("IsHit", true);
        actor.GetComponentInChildren<ParticleSystem>().Play();
        actor.GetComponent<AudioSource>().Play();

        actor.GetComponent<ActorStats>().Hurt(5);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        actor.GetComponent<Animator>().SetBool("IsHit", false);
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        if (timer > 0.5f)
        {
            return new Santa_IdleState();
        }
        else
        {
            if (actor.GetComponent<ActorStats>().isDead())
                return new Santa_DeathState();

            timer += dt;
            return null;
        }
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
