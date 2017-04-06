using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSound : MonoBehaviour {

    // reference the scoretext that will be incremented
    public ScoreController sc;


    AudioSource boardEffect;

    void OnCollisionEnter()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        boardEffect.Play();
    }
    // Use this for initialization
    void Start()
    {
        boardEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
