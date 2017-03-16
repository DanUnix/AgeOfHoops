using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            Application.Quit();
        }
    }
}
