using System;
using UnityEngine;

public class Santa_IdleState : I_ActorState
{
    void I_ActorState.OnEnter(Transform actor)
    {
        Debug.Log("Santa entered idle state");
        /*
        actor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
        Transform trans = actor.GetComponent<Transform>();
        trans.localScale = new Vector3(3, 3);
        */
        
    }

    void I_ActorState.OnExit(Transform actor)
    {
        Debug.Log("Santa exited idle state");
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
        if (Input.GetMouseButton(0))
        {
            return new Santa_PunchState();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
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
