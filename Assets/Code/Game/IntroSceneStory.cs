using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class IntroSceneStory : MonoBehaviour {

    Text storyText;
    private int counter;

    public Image canvasImage;

    private bool songFadingOut;
    public AudioSource backgroundSong;
    private float startVolume;

	// Use this for initialization
	void Start () {
        counter = 0;
        storyText = GetComponent<Text>();
        startVolume = backgroundSong.volume;
        songFadingOut = false;
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
                    canvasImage.color = new Color(0, 0, 0); 
                    break;
                case 1:
                    storyText.text = "...\"a basketball team owner!\"\n\n";
                    break;
                case 2:
                    storyText.text = "end test \n\n(Press any key to continue)";
                    songFadingOut = true;
                    break;
            }
            ++counter;

        }

        if (songFadingOut)
        {
            if (backgroundSong.volume > 0)
            {
                backgroundSong.volume -= startVolume * Time.deltaTime / 5;
            }
            else
            {
                SceneManager.LoadScene("AgeOfHoops", LoadSceneMode.Single);
            }
        }
    }
}
