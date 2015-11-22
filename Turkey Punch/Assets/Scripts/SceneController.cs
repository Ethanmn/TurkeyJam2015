using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    private readonly int START_TIMER_VAL = 60, COUNTDOWN_TIMER_VAL = 4;

    private int gameTimer, countdownTimer, gameOverTimer;

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

        player1.GetComponent<ActorController>().enabled = false;
        player2.GetComponent<ActorController>().enabled = false;
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
                    player1.GetComponent<ActorController>().enabled = true;
                    player2.GetComponent<ActorController>().enabled = true;
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
                    if (gameTimer <= 0)
                        ui.TimerText.text = "0";

                    gameOverTimer = (int)Time.timeSinceLevelLoad;
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
                {
                    ui.AnnouncerText.text = "TIME'S UP!";
                    if (player1Stats.CurrentHealth < player2Stats.CurrentHealth)
                    {
                        player1.GetComponent<ActorController>().SetState(new Santa_DeathState());
                        player2.GetComponent<ActorController>().SetState(new Turkey_VictoryState());
                    }
                    else if (player1Stats.CurrentHealth > player2Stats.CurrentHealth)
                    {
                        player1.GetComponent<ActorController>().SetState(new Santa_VictoryState());
                        player2.GetComponent<ActorController>().SetState(new Turkey_DeathState());
                    }
                    else
                    {
                        player1.GetComponent<ActorController>().SetState(new Santa_DeathState());
                        player2.GetComponent<ActorController>().SetState(new Turkey_DeathState());
                    }
                }
                else
                {
                    ui.AnnouncerText.text = "K.O.";
                    if (player1Stats.isDead())
                    {
                        player2.GetComponent<ActorController>().SetState(new Turkey_VictoryState());
                    }
                    else
                    {
                        player1.GetComponent<ActorController>().SetState(new Santa_VictoryState());

                    }
                }
                if (Time.timeSinceLevelLoad - gameOverTimer > 10)
                {
                    Application.LoadLevel("MainMenu");
                }
                nextState = currentState;
                break;
        }
        currentState = nextState;
	}
}
