using UnityEngine;

public class GUIScript : MonoBehaviour
{
    private readonly int START_TIMER_VAL = 90;

    private GUIStyle guiStyle;
    private int timer;

    private float p1life;
    private float p2life;

    public void Start() {
        p1life = 100;
        p2life = 100;
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        timer = START_TIMER_VAL;
    }
    public void Update() {
        /* TO DO: Implement these functions on hitbox collisions. */
        if (Input.GetKeyUp(KeyCode.A))
        {
            timer--;
            DamageP1(5);
            print(p1life);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            DamageP2(50);
            print(p2life);
        }

        /* draw and update timer */
        OnGUI();
        TimerUpdate();
    }

    /* this function draws the timer to the screen */
    private void OnGUI() {
        GUI.Label(new Rect(400, 400, 400, 400), timer.ToString(), guiStyle);
    }
    private void TimerUpdate() {
        timer = START_TIMER_VAL - (int)Time.timeSinceLevelLoad;
        if (timer <= 0) {
            /* TO DO: Implement game over mechanic here. */
        }
    }

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
    
    private void CheckLife(int player) { /* perhaps modify return type to int? */ 
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