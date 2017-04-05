using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour {

    Text storyText;
	// Use this for initialization
	void Start () {
        storyText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("AgeOfHoops", LoadSceneMode.Single);
        }
    }
}
