using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    // Label for which the Score text will be updated per shot
    public Text ScoreLabel;

    // The Score Counter
    public int Score;

    // Use this for initialization
    void Start()
    {
        // Set initial game score to 0
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Print Score to UI
        ScoreLabel.text = "Score: " + Score;
    }
}
