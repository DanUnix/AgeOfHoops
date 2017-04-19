using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Timer Label
    public Text timerLabel;

    // RoundCounter controller
    public RoundCounter rc;
    private int r;
    // The time that will be displayed to the user
    private float time;
    
	// Use this for initialization
	void Start () {
        time = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {

        // Using deltaTime
        time -= Time.deltaTime;

        // Update the time on the label
        // Round time to have only two decimal places
        System.Math.Round(time, 2);
        // Update the new times
        timerLabel.text = "Timer: " + string.Format(time.ToString("0.00"));
        if (time <= 0)
        {
            time = 30.0f;
            rc.updateRoundLabel();
            
        }
	}
}
