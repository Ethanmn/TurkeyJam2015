using System;
using UnityEngine;

public class Turkey_IdleState : I_ActorState
{
    private Animator santaAnim;

    void I_ActorState.OnEnter(Transform actor)
    {
        //Debug.Log("Turkey entered idle state");

        actor.GetComponent<Animator>().SetFloat("MoveSpeed", 0);
    }

    void I_ActorState.OnExit(Transform actor)
    {
        //Debug.Log("Turkey exited idle state");
    }

    I_ActorState I_ActorState.Update(Transform actor, float dt)
    {
        Vector3 leftFace = new Vector3(-1, 1);
        Vector3 rightFace = new Vector3(1, 1);

        if (actor.transform.localPosition.x > GameObject.FindGameObjectWithTag("Santa").GetComponent<Transform>().localPosition.x)
            actor.localScale = leftFace;
        else
            actor.localScale = rightFace;

        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        ActorController ac = actor.GetComponent<ActorController>();

        if (Input.GetKey(ac.ATTACK1))
        {
            return new Turkey_PunchState();
        }
        else if (Input.GetKey(ac.SPECIAL))
        {
            if (actor.GetComponent<ActorStats>().SpecialCharge >= 50)
                return new Turkey_SpecialState();
        }
        else if (Input.GetKey(ac.BLOCK))
        {
            return new Turkey_BlockState();
        }
        else if (Input.GetKey(ac.LEFT) || Input.GetKey(ac.RIGHT))
        {
            return new Turkey_WalkState();
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
