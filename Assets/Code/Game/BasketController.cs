using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

    // reference the scoretext that will be incremented
    public ScoreController sc;

    void OnCollisionEnter()
    {

    }

    void OnTriggerEnter()
    {
        sc.Score += 1;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
