using UnityEngine;
using System.Collections;

public class SantaController : ActorController {

	// Use this for initialization
	public override void Start () {
        startState = new Santa_IdleState();

        base.Start();
	}
}
