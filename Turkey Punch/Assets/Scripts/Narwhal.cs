﻿using UnityEngine;
using System.Collections;

public class Narwhal : MonoBehaviour {

    Animator anim;

    float time = 1.33f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!anim.GetBool("GoTime"))
        {
            int chance = Random.Range(0, 1001);

            if (chance == 0)
            {
                anim.SetBool("GoTime", true);
            }
        }
        else
        {
            // wait the duration, turn off go time
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 1.33f;
                anim.SetBool("GoTime", false);
            }
        }
	}
}
