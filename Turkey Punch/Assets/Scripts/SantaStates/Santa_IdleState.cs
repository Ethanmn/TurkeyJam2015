using System;
using UnityEngine;

public class Santa_IdleState : I_ActorState
{
    private Animator santaAnim;

    void I_ActorState.OnEnter(Transform actor)
    {
        actor.GetComponent<Animator>().SetFloat("MoveSpeed", 0);

        /*
        actor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
        Transform trans = actor.GetComponent<Transform>();
        trans.localScale = new Vector3(3, 3);
        */
        
    }

    void I_ActorState.OnExit(Transform actor)
    {
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        /*
        Transform trans = actor.GetComponent<Transform>();
        float time = Time.time;
        trans.localPosition = new Vector3(Mathf.Sin(time), Mathf.Cos(time));
        */
        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        ActorController ac = actor.GetComponent<ActorController>();

        if (Input.GetKeyDown(ac.ATTACK1))
        {
            return new Santa_PunchState();
        }

        if (Input.GetKeyDown(ac.LEFT) || Input.GetKeyDown(ac.RIGHT))
        {
            return new Santa_WalkState();
        }

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
