using System;
using UnityEngine;

public class Turkey_BlockState : I_ActorState
{
    // Timer to hold the animation
    private float timer;

    // Time to block
    private float blockTime = 1f;

    void I_ActorState.OnEnter(Transform actor)
    {
        //Debug.Log("Santa entered punch state");

        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsBlocking", true);

        // Reset the timer
        timer = 0;

        // Enable the block box so it can hit things
        actor.FindChild("TurkeyHitBox").GetComponent<Collider2D>().enabled = false;
    }

    void I_ActorState.OnExit(Transform actor)
    {
        //Debug.Log("Santa exited punch state");

        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsBlocking", false);

        // Dissable the block box so it doesn't hit things
        actor.FindChild("TurkeyHitBox").GetComponent<Collider2D>().enabled = true;
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        // If block animation is over
        if (timer >= blockTime)
        {
            // Exit the state
            return new Turkey_IdleState();
        }
        else
        {
            // Increment the timer
            timer += dt;
            // Stay in the state
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
