using UnityEngine;
using System.Collections;

public class TurkeyPunch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // When the punch makes contact
    void OnTriggerEnter2D(Collider2D col)
    {
        // If the other hit box is the Turkey's hitbox
        if (col.name == "TurkeyHitBox" && !(col.transform.parent == gameObject.transform.parent))
        {
            Debug.Log("HIT THE TURKEY!");
            // Hit the Turkey
            col.GetComponentInParent<ActorController>().SetState(new Turkey_HitState());
        }

        // If the other hit box is Santa's hitbox
        else if (col.name == "SantaHitBox")
        {
            Debug.Log("HIT THE SANTA! " + col.transform.parent.name);
            // Hit the Santa
            col.GetComponentInParent<ActorController>().SetState(new Santa_HitState());
        }
    }
}
