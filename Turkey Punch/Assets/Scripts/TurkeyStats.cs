using UnityEngine;
using System.Collections;

public class TurkeyStats : ActorStats
{
    void Start()
    {
        this.maxHealth = 100;
        this.currentHealth = maxHealth;
    }
}
