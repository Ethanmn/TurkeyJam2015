﻿using System;
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
        Vector3 leftFace = new Vector3(-1, 1);
        Vector3 rightFace = new Vector3(1, 1);

        if (actor.transform.localPosition.x > GameObject.FindGameObjectWithTag("Turkey").GetComponent<Transform>().localPosition.x)
            actor.localScale = leftFace;
        else
            actor.localScale = rightFace;
        return null;
    }

    I_ActorState I_ActorState.HandleInput(Transform actor)
    {
        ActorController ac = actor.GetComponent<ActorController>();

        if (Input.GetKeyDown(ac.ATTACK1))
        {
            return new Santa_PunchState();
        }
        else if (Input.GetKey(ac.SPECIAL))
        {
            if (actor.GetComponent<ActorStats>().SpecialCharge >= 50)
                return new Santa_SpecialState();
        }
        else if (Input.GetKey(ac.BLOCK) && actor.GetComponent<ActorStats>().BlockCD <= 0)
        {
            return new Santa_BlockState();
        }
        else if (Input.GetKey(ac.LEFT) || Input.GetKey(ac.RIGHT))
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
