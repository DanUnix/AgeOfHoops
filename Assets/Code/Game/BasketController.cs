﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

    // reference the scoretext that will be incremented
    public ScoreController sc;

    public RoundCounter rc;

    private int r;
    AudioSource swishEffect;

    void OnCollisionEnter()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        swishEffect.Play();
        sc.Score += 1;
        rc.updateRoundLabel();
        
    }
    // Use this for initialization
    void Start () {
        swishEffect = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
         r = rc.getRoundCounter();
	}
}
