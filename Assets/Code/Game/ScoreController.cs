using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameController gameFlow;
    public GameObject winner;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private Vector3 look;
    private Vector3 winnerPos;
    private bool setup;

    // Label for which the Score text will be updated per shot
    public Text ScoreLabel;

    // The Score Counter
    public int playerScore;
    public int aiScore;

    // Use this for initialization
    void Start()
    {
        // Set initial game score to 0
        playerScore = 0;
        aiScore = 0;
        
        setup = true;
        look = (winner.transform.position);
        look.x -= 100;
        look.y += 120;
        startTime = Time.time;
        journeyLength = Vector3.Distance(Camera.main.transform.position, look);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore >= 5)
        {
            winnerPos = winner.transform.position;
            winnerPos.y += 100;
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, look, fracJourney);
            Camera.main.transform.LookAt(winnerPos, Vector3.up);

            if(Camera.main.transform.position.y < look.y + 10)
                gameFlow.triggerVictory();
        }

        // Print Score to UI
        ScoreLabel.text = "Score\nYou vs Dennis Hotrodman\n"
            + playerScore + " : " + aiScore;
    }
}