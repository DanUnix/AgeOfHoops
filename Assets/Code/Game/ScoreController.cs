﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameController gameFlow;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore >= 5)
            gameFlow.triggerVictory();

        // Print Score to UI
        ScoreLabel.text = "Score\nYou vs Dennis Hotrodman\n"
            + playerScore + " : " + aiScore;
    }
}