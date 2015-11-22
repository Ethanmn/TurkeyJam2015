using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    Text timerText;
    Text countdownTimerText;
    private readonly int START_TIMER_VAL = 90;
    private readonly int COUNTDOWN_TIMER_VAL = 4;
    private bool gameOn = false;

    private GUIStyle guiStyle;
    private int timer;
    private int countdownTimer;

    private GameObject player1, player2;
    private ActorStats player1Stats, player2Stats;

    public void Start()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        timer = START_TIMER_VAL;
        timerText = gameObject.GetComponentsInChildren<Text>()[1];
        countdownTimerText = gameObject.GetComponentsInChildren<Text>()[0];

        player1 = GameObject.FindGameObjectWithTag("Santa");
        player2 = GameObject.FindGameObjectWithTag("Turkey");

        player1Stats = player1.GetComponent<ActorStats>();
        player2Stats = player2.GetComponent<ActorStats>();
    }

    public void Update()
    {
        transform.FindChild("P1HealthBar").transform.localScale = new Vector3(player1Stats.CurrentHealth / 100f, 1, 1);
        if (player1Stats.isDead())
        {
            GameOver(1);
        }

        transform.FindChild("P2HealthBar").transform.localScale = new Vector3(player2Stats.CurrentHealth / 100f, 1, 1);
        if (player2Stats.isDead())
        {
            GameOver(2);
        }

        /* draw and update timer */
        TimerUpdate();
    }

    /* this function draws the timer to the screen */
    private void TimerUpdate()
    {
        if (!gameOn)
        {
            countdownTimer = COUNTDOWN_TIMER_VAL - (int)Time.timeSinceLevelLoad;
            if (countdownTimer > 1) countdownTimerText.text = (countdownTimer - 1).ToString();
            else if (countdownTimer == 1) countdownTimerText.text = "FIGHT!";
            else if (countdownTimer <= -1) countdownTimerText.text = "TIME'S UP!";
            else gameOn = true;
        }
        else
        {
            countdownTimerText.text = "";
            timer = START_TIMER_VAL - (int)Time.timeSinceLevelLoad + COUNTDOWN_TIMER_VAL;
            if (timer <= 0)
            {
                /* TO DO: Implement game over mechanic here. */
                countdownTimer = -1;
                gameOn = false;
            }
        }
        timerText.text = timer.ToString();
    }

    public void GameOver(int player)
    {
        switch (player)
        {
            case 1:
                Debug.Log("Player 1 wins!");
                break;
            case 2:
                Debug.Log("Player 2 wins!");
                break;
        }
    }
}