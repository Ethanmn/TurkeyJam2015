﻿using System;
using UnityEngine;

public class Turkey_HitState : I_ActorState
{
    float timer = 0;
    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Turkey entered hit state");
        //actor.GetComponent<Animator>().SetBool("IsHit", true);
        actor.GetComponentInChildren<ParticleSystem>().Play();
    }

    void I_ActorState.OnExit(Transform actor)
    {
        //Debug.Log("Turkey exited hit state");
        //actor.GetComponent<Animator>().SetBool("IsHit", false);
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        if (timer > 0.5f)
        {
            return new Turkey_IdleState();
        }
        else
        {
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
