using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameController gameFlow;
    public int winScore;

    // Label for which the Score text will be updated per shot
    public Text ScoreLabel;

    // The Score Counter
    public int playerScore;
    public int aiScore;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("loadStatus") == 1)
        {
            playerScore = PlayerPrefs.GetInt("myPoint");
            aiScore = PlayerPrefs.GetInt("enemyPoint");
        }
        else
        {
            // Set initial game score to 0
            playerScore = 0;
            aiScore = 0;
        }
        
        winScore = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // Print Score to UI
        ScoreLabel.text = "Score\nYou vs Dennis Hotrodman\n"
            + playerScore + " : " + aiScore;
        PlayerPrefs.SetInt("myPoint", playerScore);
        PlayerPrefs.SetInt("enemyPoint", aiScore);
    }
}