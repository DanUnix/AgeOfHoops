using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerLabel;

    private float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;


        var minutes = time / 60;
        var seconds = time % 60;
        var frac = (time * 100) % 100;


        // Update the time on the label
        timerLabel.text = "Timer: " + string.Format("{1:00} : {2:00}", minutes, seconds, frac);
        	
	}
}
