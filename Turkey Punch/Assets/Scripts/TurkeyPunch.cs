using UnityEngine;
using System.Collections;

public class TurkeyPunch : MonoBehaviour {

    // When the punch makes contact
    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 0;

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
