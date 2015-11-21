using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Colliding with " + col.gameObject.name);
    }
}