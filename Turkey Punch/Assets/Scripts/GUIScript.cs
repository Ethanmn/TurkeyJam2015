using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour
{
    Text timerText, mainDisplayText; // the text drawn to the screen
    private string toDisplay = "";
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
        mainDisplayText = gameObject.GetComponentsInChildren<Text>()[0]; // see line above

        player1 = GameObject.FindGameObjectWithTag("Santa");
        player2 = GameObject.FindGameObjectWithTag("Turkey");

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

        MainDisplay(toDisplay);
    }

    private void MainDisplay(string s)
    {
        mainDisplayText.text = s;
    }

    /* this function draws the timer to the screen */
    private void TimerUpdate()
    {
        if (!gameOn) // countdown timer should be running (game timer should not)
        {
            if (countdownTimerRunning) countdownTimer = COUNTDOWN_TIMER_VAL - (int)Time.timeSinceLevelLoad; // updates the countdown timer's value
            if (countdownTimer > 1) toDisplay = (countdownTimer - 1).ToString(); // updates countdown timer's text
            else if (countdownTimer == 1) toDisplay = "Fight!";
            else if (countdownTimer == 0)
            {
                toDisplay = "";
                countdownTimerRunning = false;
                gameOn = true;
            }
            else if (countdownTimer == -1000) { } // dontask.jpg...
            else if (countdownTimer <= -1) gameOn = true; // when countdown timer is finished, starts the games
        }
        else // countdown timer is finished counting down.
        {
            timer = START_TIMER_VAL - (int)Time.timeSinceLevelLoad + COUNTDOWN_TIMER_VAL; // updates timer
            if (timer <= 0)
            {
                toDisplay = "Time's up!";
                GameOver(0); // checks each players health and makes a verdict on who won based on that
                countdownTimer = -1000;

            }
        }
        timerText.text = timer.ToString();
    }

    public void GameOver(int player)
    {
        gameOn = false;
        countdownTimer = -1000;
        switch (player)
        {
            case 0:
                if (player1Stats.CurrentHealth > player2Stats.CurrentHealth)
                    toDisplay = "Player 1\nwins!";
                else if (player2Stats.CurrentHealth > player1Stats.CurrentHealth)
                    toDisplay = "Player 2\nwins!";
                else
                    toDisplay = "It's a tie!";
                break;
            case 1:
                toDisplay = "Player 1\nwins!";
                break;
            case 2:
                toDisplay = "Player 2\nwins!";
                break;
        }
    }
}