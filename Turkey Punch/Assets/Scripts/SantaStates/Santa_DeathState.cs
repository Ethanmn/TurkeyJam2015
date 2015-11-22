﻿using System;
using UnityEngine;

class Santa_DeathState : I_ActorState
{
    public void OnEnter(Transform actor)
    {
        Debug.Log("Santa is dead :(");
    }

    public void OnExit(Transform actor)
    {
        
    }

    public I_ActorState Update(Transform actor, float dt)
    {
        return null;
    }

    public I_ActorState HandleInput(Transform actor)
    {
        return null;
    }

    public I_ActorState OnCollisionEnter(Transform actor, Collision2D c)
    {
        return null;
    }

    public I_ActorState OnCollisionStay(Transform actor, Collision2D c)
    {
        return null;
    }
}
