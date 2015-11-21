using System;
using UnityEngine;

public class Santa_WalkState : I_ActorState
{
    int facing = 0;

    static float maxSpeed = 0.1f;

    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Santa entered walk state");
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Santa exited walk state");
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
        else if (!Input.GetKey(ac.LEFT) && !Input.GetKey(ac.RIGHT))
        {
            return new Santa_IdleState();
        }
        else
        {
            Move(actor);
            return null;
        }
    }

    I_ActorState I_ActorState.OnCollisionEnter(Transform actor, Collision2D c)
    {
        return null;
    }

    I_ActorState I_ActorState.OnCollisionStay(Transform actor, Collision2D c)
    {
        return null;
    }

    void Move(Transform actor)
    {
        ActorController ac = actor.GetComponent<ActorController>();
        Transform trans = actor.GetComponent<Transform>();

        Vector3 moveDir = new Vector3();

        Vector3 leftFace = new Vector3(-1, 1);
        Vector3 rightFace = new Vector3(1, 1);

        ParticleSystem snow = actor.gameObject.GetComponentInChildren<ParticleSystem>();

        if (Input.GetKey(ac.LEFT))
        {
            // Direction is move left 

            moveDir.x = -maxSpeed;

            // Flip Santa's model left
            actor.localScale = leftFace;
            /*
            // Flip snow particle engine left
            if (facing != 1)
                snow.transform.localRotation = new Quaternion(snow.transform.localRotation.x, -snow.transform.localRotation.y, snow.transform.localRotation.z, snow.transform.localRotation.w);
            
            // Play the effect
            if (UnityEngine.Random.Range(0, 11) % 5 == 0)
                snow.Play();
                */

            facing = 1;
        }
        else if (Input.GetKey(ac.RIGHT))
        {
            // Direction is move right

            moveDir.x = maxSpeed;

            // Flip Santa's model right
            actor.localScale = rightFace;
            /*
            // Flip snow particle engine right
            if (facing != 0)
            snow.transform.localRotation = new Quaternion(snow.transform.localRotation.x, -snow.transform.localRotation.y, snow.transform.localRotation.z, snow.transform.localRotation.w);
            
            // Play the effect
            if (UnityEngine.Random.Range(0, 11) % 5 == 0)
                snow.Play();
                */

            facing = 0;
        }

        trans.Translate(moveDir);
    }
}
