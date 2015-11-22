using System;
using UnityEngine;

public class Santa_PunchState : I_ActorState
{
    // Timer to hold the animation
    private float timer;

    // Punch Time
    private float punchTime = 0.6f;

    void I_ActorState.OnEnter(Transform actor)
    {
        //Debug.Log("Santa entered punch state");

        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsPunching", true);

        // Reset the timer
        timer = 0;

        actor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        // Enable the hit box so it can hit things
        actor.FindChild("PunchHitBox").GetComponent<BoxCollider2D>().enabled = true;
    }

    void I_ActorState.OnExit(Transform actor)
    {
        //Debug.Log("Santa exited punch state");

        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsPunching", false);

        // Dissable the hit box so it doesn't hit things
        actor.FindChild("PunchHitBox").GetComponent<BoxCollider2D>().enabled = false;
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        // If attack animation is over
        if (timer >= punchTime)
        {
            // Exit the state
            return new Santa_IdleState();
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
