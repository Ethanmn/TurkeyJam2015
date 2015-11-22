using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    private readonly int START_TIMER_VAL = 90, COUNTDOWN_TIMER_VAL = 4;

    private int gameTimer, countdownTimer;

    private UIScript ui;

    private GameObject player1, player2;
    private ActorStats player1Stats, player2Stats;

    enum GameState { Countdown, Fight, Over};
    private GameState currentState, nextState;

    // Use this for initialization
    void Start () {
        gameTimer = START_TIMER_VAL;
        countdownTimer = COUNTDOWN_TIMER_VAL;
        currentState = nextState = GameState.Countdown;

        ui = GameObject.FindGameObjectWithTag("GUICanvas").GetComponent<UIScript>();

        player1 = GameObject.FindGameObjectWithTag("Santa");
        player2 = GameObject.FindGameObjectWithTag("Turkey");

        player1Stats = player1.GetComponent<ActorStats>();
        player2Stats = player2.GetComponent<ActorStats>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case GameState.Countdown:
                ui.TimerText.text = START_TIMER_VAL.ToString();
                countdownTimer = COUNTDOWN_TIMER_VAL - (int)Time.timeSinceLevelLoad;
                if (countdownTimer > 1)
                {
                    ui.AnnouncerText.text = (countdownTimer - 1).ToString();
                    nextState = currentState;
                }
                else if (countdownTimer > 0)
                {
                    ui.AnnouncerText.text = "FIGHT!";
                    nextState = currentState;
                }
                else
                {
                    nextState = GameState.Fight;
                }
                break;
            case GameState.Fight:
                ui.AnnouncerText.text = "";
                gameTimer = START_TIMER_VAL - (int)Time.timeSinceLevelLoad + COUNTDOWN_TIMER_VAL;

                if (player1Stats.isDead() || player2Stats.isDead() || gameTimer <= 0)
                {
                    ui.TimerText.text = "0";
                    nextState = GameState.Over;
                }
                else
                {
                    ui.TimerText.text = gameTimer.ToString();
                    nextState = currentState;
                }
                break;
            case GameState.Over:
                if (gameTimer <= 0)
                    ui.AnnouncerText.text = "TIME'S UP";
                else
                    ui.AnnouncerText.text = "K.O.";
                nextState = currentState;
                break;
        }
        currentState = nextState;
	}
}
