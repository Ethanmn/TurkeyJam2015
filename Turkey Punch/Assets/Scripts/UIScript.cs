using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    Text timerText, announcerText; // the text drawn to the screen
    public Text TimerText { get { return timerText; } set { timerText = value; } }
    public Text AnnouncerText { get { return announcerText; } set { announcerText = value; } }

    private ActorStats player1Stats;
    private ActorStats player2Stats;

    private float priorHP1, priorHP2;
    private readonly float decreaseSpeed = 4f;

    public void Start()
    {
        player1Stats = GameObject.FindGameObjectWithTag("Santa").GetComponent<ActorStats>();
        player2Stats = GameObject.FindGameObjectWithTag("Turkey").GetComponent<ActorStats>();

        priorHP1 = player1Stats.CurrentHealth;
        priorHP2 = player2Stats.CurrentHealth;

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
        if (player1Stats.CurrentHealth < priorHP1)
        {
            priorHP1 = Mathf.Lerp(priorHP1, player1Stats.CurrentHealth, decreaseSpeed * Time.deltaTime * (priorHP1 + player1Stats.CurrentHealth) / player1Stats.CurrentHealth);
            GameObject.FindGameObjectWithTag("P1HealthBar").GetComponent<Transform>().localScale = new Vector3(priorHP1 / 100, 1, 1);//player1Stats.CurrentHealth / 100f, 1, 1);
        }
        if (player2Stats.CurrentHealth < priorHP2)
        {
            priorHP2 = Mathf.Lerp(priorHP2, player2Stats.CurrentHealth, decreaseSpeed * Time.deltaTime * (priorHP2 + player2Stats.CurrentHealth) / player2Stats.CurrentHealth);
            GameObject.FindGameObjectWithTag("P2HealthBar").GetComponent<Transform>().localScale = new Vector3(priorHP2 / 100, 1, 1);//player2Stats.CurrentHealth / 100f, 1, 1);
        }
        
    }

    public void UpdateSpecialBars()
    {
        GameObject.FindGameObjectWithTag("P1SpecialBar").GetComponent<Transform>().localScale = new Vector3(player1Stats.SpecialCharge / 50f, 1, 1);
        GameObject.FindGameObjectWithTag("P2SpecialBar").GetComponent<Transform>().localScale = new Vector3(player2Stats.SpecialCharge / 50f, 1, 1);
    }
}