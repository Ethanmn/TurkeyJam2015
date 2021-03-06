﻿using System;
using UnityEngine;

public class Santa_HitState : I_ActorState
{
    float timer = 0;
    private int damage = 5;

    public Santa_HitState(int damage)
    {
        this.damage = damage;
    }

    void I_ActorState.OnEnter(Transform actor)
    {
        actor.GetComponent<Animator>().SetBool("IsHit", true);
        actor.GetComponentInChildren<ParticleSystem>().Play();
        actor.GetComponents<AudioSource>()[0].Play();

        actor.GetComponent<ActorStats>().Hurt(damage);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        actor.GetComponent<Animator>().SetBool("IsHit", false);
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        if (timer > 0.6f)
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
