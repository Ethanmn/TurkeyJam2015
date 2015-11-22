using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    Text timerText, countdownTimerText; // the text drawn to the screen
    private readonly int START_TIMER_VAL = 90, COUNTDOWN_TIMER_VAL = 4; // the initial timer conditions NOTE: countdownTimerVal should be 1 greater than desired value.
    private bool gameOn = false; // start the game immediately: true, start after countdown timer: false
    private bool countdownTimerRunning = true;
    
    private int timer, countdownTimer; 

    private GameObject player1, player2; 
    private ActorStats player1Stats, player2Stats;

    public void Start()
    {
        timer = START_TIMER_VAL; // initialize timer value
        timerText = gameObject.GetComponentsInChildren<Text>()[1]; // initialize timer's text (NOTE: value may change based on ordering in gameobject)
        countdownTimerText = gameObject.GetComponentsInChildren<Text>()[0]; // see line above

        player1 = GameObject.FindGameObjectWithTag("Santa");
        player2 = GameObject.FindGameObjectWithTag("Turkey");

        print("Santa " + player1);
        print("Turkey " + player2);

        player1Stats = player1.GetComponent<ActorStats>();
        player2Stats = player2.GetComponent<ActorStats>();
    }

    public void Update() /* this method updates the health bars with respect to the each player's health stats */
    {
        transform.FindChild("GUI").transform.FindChild("P1HealthBar").transform.localScale = new Vector3(player1Stats.CurrentHealth / 100f, 1, 1);
        if (player1Stats.isDead())
        {
            GameOver(1);
        }

        transform.FindChild("GUI").transform.FindChild("P2HealthBar").transform.localScale = new Vector3(player2Stats.CurrentHealth / 100f, 1, 1);
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
        if (!gameOn) // countdown timer should be running (game timer should not)
        {
            if (countdownTimerRunning) countdownTimer = COUNTDOWN_TIMER_VAL - (int)Time.timeSinceLevelLoad; // updates the countdown timer's value
            if (countdownTimer > 1) countdownTimerText.text = (countdownTimer - 1).ToString(); // updates countdown timer's text
            else if (countdownTimer == 1) {
                countdownTimerText.text = "FIGHT!";
                countdownTimer = 0;
                countdownTimerRunning = false;
            }
            else if (countdownTimer <= -1) countdownTimerText.text = "TIME'S UP!";
            else {
                gameOn = true; // when countdown timer is finished, starts the games
                countdownTimerText.text = ""; // not nullifying the text string will keep displaying text to the screen. keep this null.
            }
        }
        else // countdown timer is finished counting down.
        {
            timer = START_TIMER_VAL - (int)Time.timeSinceLevelLoad + COUNTDOWN_TIMER_VAL; // updates timer
            if (timer <= 0)
            {
                GameOver(0); // checks each players health and makes a verdict on who won based on that
                countdownTimer = -1; // displays "TIME'S UP!" to the screen
            }
        }
        timerText.text = timer.ToString();
    }

    public void GameOver(int player)
    {
        gameOn = false;
        switch (player)
        {
            case 0:
                if (player1Stats.CurrentHealth > player2Stats.CurrentHealth)
                    Debug.Log("Player 1 wins!");
                else if (player2Stats.CurrentHealth > player1Stats.CurrentHealth)
                    Debug.Log("Player 2 wins!");
                else
                    Debug.Log("It's a tie!");
                break;
            case 1:
                Debug.Log("Player 1 wins!");
                break;
            case 2:
                Debug.Log("Player 2 wins!");
                break;
        }
    }
}