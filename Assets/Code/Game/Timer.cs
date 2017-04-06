using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerLabel;

    private float time = 30.0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        time -= Time.deltaTime;

        // Update the time on the label
        System.Math.Round(time, 2);
        timerLabel.text = "Timer: " + string.Format(time.ToString("0.00"));
        if (time <= 0)
        {
            time = 30.0f;
        }
	}
}
