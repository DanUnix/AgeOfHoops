using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class IntroSceneStory : MonoBehaviour {

    Text storyText;
    private int counter;

	// Use this for initialization
	void Start () {
        counter = 0;
        storyText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            switch (counter)
            {
                case 0:
                    storyText.fontSize = 23;
                    storyText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                    storyText.text = "\"Finally, I can be what I've always dreamed of,\" you thought...\n\n";
                    break;
                case 1:
                    storyText.text = "...\"a basketball team owner!\"\n\n";
                    break;
                case 2:
                    storyText.text = "end test \n\n(Press any key to continue)";
                    SceneManager.LoadScene("AgeOfHoops", LoadSceneMode.Single);
                    break;
            }
            ++counter;

        }
    }
}
