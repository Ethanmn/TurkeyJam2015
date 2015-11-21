using UnityEngine;

public class GUIScript : MonoBehaviour
{
    private readonly float HEALTH_BAR_WIDTH = 370.9f;

    public float p1life;
    public float p2life;

    public void Start() {
        p1life = 100;
        p2life = 100;
    }
    public void Update() {
        /* Uncomment these to see the health bars move at a constant rate.
              TO DO: Implement these functions on hitbox collisions.
        */
        /*DamageP1(1);
        DamageP2(1);*/
        if (Input.GetKeyUp(KeyCode.A))
        {
            DamageP1(5);
            print(p1life);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            DamageP2(50);
            print(p2life);
        }
    }

    /* TO DO: Figure out scale amount to connect 1 point of damage to 
          1/100th of the health bar (perhaps 1/3.709 or something to that effect?) */
    public void DamageP1(float amount) {
        p1life -= amount;
        transform.FindChild("P1HealthBar").transform.localScale += new Vector3((float)(-.01* amount), 0, 0);
        CheckLife(1);
    }
    public void DamageP2(float amount) {
        p2life -= amount;
        transform.FindChild("P2HealthBar").transform.localScale += new Vector3((float)(-.01 * amount), 0, 0);
        CheckLife(2);
    }
    
    private void CheckLife(int player) /* perhaps modify return type to int? */
    {
        switch (player)
        {
            case 1:
                if (p1life <= 0) {
                    /* TO DO: Implement defeat script */
                }
                break;
            case 2:
                if (p2life <= 0)
                {
                    /* TO DO: Implement defeat script */
                }
                break;
        }
    }
}