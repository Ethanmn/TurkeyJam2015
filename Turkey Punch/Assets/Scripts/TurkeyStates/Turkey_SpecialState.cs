using System;
using UnityEngine;

public class Turkey_SpecialState : I_ActorState
{
    // Timer to hold the animation
    private float animTimer, timer;

    // Attack Time
    private float animTime = 0.5833f;
    private float time = 2f;

    void I_ActorState.OnEnter(Transform actor)
    {
        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsSpecial", true);

        // Reset the timer
        animTimer = 0;
        timer = 0;

        // Reset the speical charge
        actor.GetComponent<ActorStats>().SpecialCharge = 0;

        actor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        // Dissable the hit box so Turkey is invincible during special
        //actor.FindChild("TurkeyHitBox").GetComponent<Collider2D>().enabled = false;
        // Enable block hitbox
        actor.FindChild("BlockHitBox").GetComponent<Collider2D>().enabled = true;
    }

    void I_ActorState.OnExit(Transform actor)
    {
        // Set the animation flag
        actor.GetComponent<Animator>().SetBool("IsSpecial", false);

        // Enable the hit box
        actor.FindChild("TurkeyHitBox").GetComponent<Collider2D>().enabled = true;

        actor.FindChild("BlockHitBox").GetComponent<Collider2D>().enabled = false;
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {

        if (timer >= time)
        {
            return new Turkey_IdleState();
        }
        else
        {
            timer += Time.deltaTime;
        }

        // If attack animation is over
        if (animTimer >= animTime)
        {
            // SHOOP DA WOOOP
            GameObject SHOOP = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Goblaser"));
            SHOOP.transform.parent = actor;
            SHOOP.transform.localPosition = new Vector3(0, 3, 0);
            animTimer = -1;
            return null;
        }
        else if (animTimer >= 0)
        {
            // Increment the timer
            animTimer += dt;
            // Stay in the state
            return null;
        }
        return null;
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
