using UnityEngine;
using System.Collections;

public abstract class ActorStats : MonoBehaviour {
    protected int currentHealth, maxHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Max(0, Mathf.Min(value, MaxHealth)); }
    }

    public int MaxHealth { get { return maxHealth; } }

    public int Hurt(int damage)
    {
        CurrentHealth -= damage;

        return CurrentHealth;
    }

    public bool isDead()
    {
        return CurrentHealth == 0;
    }
}
