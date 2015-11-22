using UnityEngine;
using System.Collections;

public class Slay : MonoBehaviour {
    float timer = 0;
    float time = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (timer < time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        // If the other hit box is the Turkey's hitbox
        if (col.name == "TurkeyHitBox")
        {
            // Hit the Turkey
            col.GetComponentInParent<ActorController>().SetState(new Turkey_HitState(5));
        }
    }
}
