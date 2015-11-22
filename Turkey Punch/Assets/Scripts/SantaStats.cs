using UnityEngine;
using System.Collections;

public class SantaStats : ActorStats
{
	void Start()
    {
        this.maxHealth = 100;
        this.currentHealth = maxHealth;
        this.specialCharge = 0;
    }
}
