using UnityEngine;
using System.Collections;

public class SantaPunch : MonoBehaviour {

    // When the punch makes contact
    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 0;

        // If the other hit box is the Turkey's hitbox
        if (col.name == "TurkeyHitBox")
        {
            //Debug.Log("HIT THE TURKEY!");
            // Hit the Turkey
            col.GetComponentInParent<ActorController>().SetState(new Turkey_HitState(5));
        }

        // If the other hit box is Santa's hitbox
        if (col.name == "SantaHitBox" && !(col.transform.parent == gameObject.transform.parent))
        {
            //Debug.Log("HIT THE SANTA! " + col.transform.parent.name);
            // Hit the Santa
            col.GetComponentInParent<ActorController>().SetState(new Santa_HitState(5));
        }
        else if (col.name == "BlockHitBox" && !(col.transform.parent == gameObject.transform.parent))
        {
            transform.parent.gameObject.GetComponent<ActorController>().SetState(new Santa_HitState(0));
        }
    }
}
