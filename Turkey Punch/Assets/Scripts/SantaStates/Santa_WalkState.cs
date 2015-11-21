using System;
using UnityEngine;

public class Santa_WalkState : I_ActorState
{
    int facing = 0;

    void I_ActorState.OnEnter(Transform actor)
    {
        //actor.GetComponent<Transform>().localScale = new Vector3(3, 3);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        //actor.GetComponent<Transform>().localScale = new Vector3(1, 1);
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        if (Input.GetMouseButtonDown(0))
        {
            return new Santa_PunchState();
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
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
        Vector3 moveDir = new Vector3();

        Vector3 leftFace = new Vector3(-1, 1);
        Vector3 rightFace = new Vector3(1, 1);

        ParticleSystem snow = actor.gameObject.GetComponentInChildren<ParticleSystem>();

        if (Input.GetKey(KeyCode.A))
        {
            // Direction is move left 
            moveDir.x = -0.1f;
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
        else if (Input.GetKey(KeyCode.D))
        {
            // Direction is move right
            moveDir.x = 0.1f;
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

        actor.GetComponent<Animator>().SetFloat("MoveSpeed", Math.Abs(moveDir.x));

        actor.Translate(moveDir);
    }
}
