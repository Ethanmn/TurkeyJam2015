using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    Text timerText, announcerText; // the text drawn to the screen
    public Text TimerText { get { return timerText; } set { timerText = value; } }
    public Text AnnouncerText { get { return announcerText; } set { announcerText = value; } }

    private ActorStats player1Stats;
    private ActorStats player2Stats;

    public void Start()
    {
        player1Stats = GameObject.FindGameObjectWithTag("Santa").GetComponent<ActorStats>();
        player2Stats = GameObject.FindGameObjectWithTag("Turkey").GetComponent<ActorStats>();

        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>();
        announcerText = GameObject.FindGameObjectWithTag("AnnouncerText").GetComponent<Text>();
    }

    public void Update() /* this method updates the health bars with respect to the each player's health stats */
    {
        UpdateHPBars();
        UpdateSpecialBars();
    }

    public void UpdateHPBars()
    {
        GameObject.FindGameObjectWithTag("P1HealthBar").GetComponent<Transform>().localScale = new Vector3(player1Stats.CurrentHealth / 100f, 1, 1);
        GameObject.FindGameObjectWithTag("P2HealthBar").GetComponent<Transform>().localScale = new Vector3(player2Stats.CurrentHealth / 100f, 1, 1);  
    }

    public void UpdateSpecialBars()
    {
        GameObject.FindGameObjectWithTag("P1SpecialBar").GetComponent<Transform>().localScale = new Vector3(player1Stats.SpecialCharge / 50f, 1, 1);
        GameObject.FindGameObjectWithTag("P2SpecialBar").GetComponent<Transform>().localScale = new Vector3(player2Stats.SpecialCharge / 50f, 1, 1);
    }
}