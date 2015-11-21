using UnityEngine;
using System.Collections;

public class SantaController : ActorController {
    

	// Use this for initialization
	public override void Start () {
        startState = new Santa_IdleState();

        left = KeyCode.A;
        right = KeyCode.D;
        jump = KeyCode.Space;
        attack1 = KeyCode.F;

        base.Start();
	}
}
