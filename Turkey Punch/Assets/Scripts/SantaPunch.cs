using UnityEngine;
using System.Collections;

public class SantaPunch : MonoBehaviour {

    // When the punch makes contact
    void OnTriggerEnter2D(Collider2D col)
    {
        // If the other hit box is the Turkey's hitbox
        if (col.name == "TurkeyHitBox")
        {
            Debug.Log("HIT THE TURKEY!");
            // Hit the Turkey
            col.GetComponentInParent<ActorController>().SetState(new Turkey_HitState());
        }

        // If the other hit box is Santa's hitbox
        if (col.name == "SantaHitBox" && !(col.transform.parent == gameObject.transform.parent))
        {
            Debug.Log("HIT THE SANTA! " + col.transform.parent.name);
            // Hit the Santa
            col.GetComponentInParent<ActorController>().SetState(new Santa_HitState());
        }
    }
}
