using System;
using UnityEngine;

class Turkey_VictoryState : I_ActorState
{
    public void OnEnter(Transform actor)
    {
        actor.GetComponent<Animator>().SetBool("IsVictory", true);
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
