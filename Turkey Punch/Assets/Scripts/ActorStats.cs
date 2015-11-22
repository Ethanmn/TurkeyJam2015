using UnityEngine;
using System.Collections;

public abstract class ActorStats : MonoBehaviour {
    protected int currentHealth, maxHealth;
    protected int specialCharge;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Max(0, Mathf.Min(value, MaxHealth)); }
    }
    public int SpecialCharge
    {
        get { return specialCharge; }
        set { specialCharge = Mathf.Min(50, value); }
    }

    public int MaxHealth { get { return maxHealth; } }

    public int Hurt(int damage)
    {
        CurrentHealth -= damage;
        SpecialCharge += damage;

        return CurrentHealth;
    }

    public bool isDead()
    {
        return CurrentHealth == 0;
    }
}
