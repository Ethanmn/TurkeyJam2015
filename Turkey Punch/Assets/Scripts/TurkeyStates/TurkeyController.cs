using UnityEngine;
using System.Collections;

public class TurkeyController : ActorController {

	// Use this for initialization
	public override void Start () {
        startState = new Turkey_IdleState();

        left = KeyCode.J;
        right = KeyCode.L;
        jump = KeyCode.RightShift;
        attack1 = KeyCode.H;

        base.Start();
	}
}
