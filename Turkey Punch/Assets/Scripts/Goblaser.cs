using UnityEngine;
using System.Collections;

public class Goblaser : MonoBehaviour {

    float tickTimer, lifeTimer, life, tick;
    int damage, tickCount;

	// Use this for initialization
	void Start () {
        tickTimer = 0;
        lifeTimer = 0;
        life = 1.2f;
        tick = 0.02f;
        damage = 2;
        tickCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // Tick
	    if (tickTimer >= tick)
        {
            tickCount++;
            tickTimer = 0;
            GameObject p1 = GameObject.FindGameObjectWithTag("Santa");
            if (GetComponent<BoxCollider2D>().bounds.Contains(p1.transform.position))
            {
                if (tickCount < 12)
                    damage = 7;
                else
                    damage = 3;
                    p1.GetComponent<ActorController>().SetState(new Santa_HitState(damage));
            }
        }
        else
        {
            tickTimer += Time.deltaTime;
        }
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= life)
        {
            Destroy(gameObject);
        }
        
	}
}
