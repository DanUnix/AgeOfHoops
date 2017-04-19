﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public HexGrid hexgrid;

    public AudioSource music;
    private bool songFading;

    private float startVolume;

	// Use this for initialization
	void Start () {
        startVolume = music.volume;
        songFading = false;      
    }
	
	// Update is called once per frame
	void Update () {
        if (hexgrid.occupiedCells[((hexgrid.height / 2) * hexgrid.width) - 1] == 1)
        {
            songFading = true;
 
        }

        if(songFading)
        {
            if(music.volume > 0)
               music.volume -= startVolume * Time.deltaTime / 5;
            else
                SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
	}
}
