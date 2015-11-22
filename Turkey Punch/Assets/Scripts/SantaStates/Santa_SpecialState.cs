using System;
using UnityEngine;

public class Santa_SpecialState : I_ActorState
{
    // Timer to hold the animation
    private float timer;

    // Attack Time
    private float attackTime = 2.5f;

    void I_ActorState.OnEnter(Transform actor)
    {
        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsSpecial", true);

        // Reset the timer
        timer = 0;
        
        // Reset the special charge
        actor.GetComponent<ActorStats>().SpecialCharge = 0;

        actor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        // Summon the SLAY
        GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Slay"));

        // Dissable the hit box so Santa is invincible during special
        actor.FindChild("SantaHitBox").GetComponent<Collider2D>().enabled = false;
    }

    void I_ActorState.OnExit(Transform actor)
    {
        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsSpecial", false);

        // Enable the hit box
        actor.FindChild("SantaHitBox").GetComponent<Collider2D>().enabled = true;
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        // If attack animation is over
        if (timer >= attackTime)
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
