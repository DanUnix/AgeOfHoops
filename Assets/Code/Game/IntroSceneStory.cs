using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class IntroSceneStory : MonoBehaviour {

    Text storyText;
    public Text clickToContinue;
    private int counter;
    private bool swapText;
    private bool finalMessage;

    public Image canvasImage;

    private bool songFadingOut;
    public AudioSource backgroundSong;
    private float startVolume;

	// Use this for initialization
	void Start () {
        counter = 0;
        swapText = true;
        finalMessage = false;

        storyText = GetComponent<Text>();
        startVolume = backgroundSong.volume;
        songFadingOut = false;
        StartCoroutine(waitMySeconds(10));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && swapText)
        {
            switch (counter)
            {
                case 0:
                    storyText.fontSize = 23;
                    storyText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                    storyText.text = "\"Finally, I can be what I've always dreamed of,\" you thought...";
                    canvasImage.color = new Color(0, 0, 0); 
                    break;
                case 1:
                    storyText.text = "...\"a basketball team owner!\"";
                    break;
                case 2:
                    storyText.text = "Ever since you saw Michael JChosen (silent J of course)\n" + 
                        "defeat the alien invaders in \'Space Jelly\',\n" + 
                        "it was your aspiration to bask in basketball glory.";
                    break;
                case 3:
                    storyText.text = "However, power corrupts...";
                    break;
                case 4:
                    storyText.text = "...and absolute power makes for a great underdog story.";
                    break;
                case 5:
                    storyText.text = "Earth's hero, Michael JChosen fell to the dark side";
                    break;
                case 6:
                    storyText.text = "...Who will stop him?...";
                    break;
                case 7:
                    storyText.text = "Only you can . . .";
                    break;
                case 8:
                    storyText.text = "And thanks to the fiscal aid of a certain\n" +
                        "African royalty, you just bought your own team:\n" +
                        "the Basketball Bonobos.";
                    break;
                case 9:
                    storyText.text = "Humble beginnings my friend, humble beginnings.";
                    break;
                case 10:
                    storyText.text = "At least we aren't forcing you to mindlessly slaughter slimes\n" +
                        "who for some godforsaken reason carry tiny bits of money on them.";
                    break;
                case 11:
                    storyText.text = "I mean what would a slime even do with money? Buy boots?\n" +
                        "Get a drink at the tavern after a hard day of sliming around?";
                    break;
                case 12:
                    storyText.text = "Hire a local wench for a good time...?";
                    break;
                case 13:
                    storyText.text = "Anyhow, let's see if you can beat this lowly henchman:\n" +
                        "Dennis Hotrodman.\n" +
                        "Ignore his rants about best Korea.";
                    break;
                case 14:
                    storyText.text = "Click and drag your characters one spot at a time till you can shoot with spacebar.\n" +
                        "Get 5 points to win.";
                    break;
                case 15:
                    storyText.text = "Good luck, and don't fuck it up.";
                    finalMessage = true;
                    break;
                case 16:
                    songFadingOut = true;
                    break;
            }
            swapText = false;
            ++counter;
            StartCoroutine(waitMySeconds(1));

        }

        if (songFadingOut)
        {
            if (backgroundSong.volume > 0)
                backgroundSong.volume -= startVolume * Time.deltaTime / 3;
            else
                SceneManager.LoadScene("AgeOfHoops", LoadSceneMode.Single);
        }
    }
    
    IEnumerator waitMySeconds(int sec)
    {
        clickToContinue.text = "";
        yield return new WaitForSeconds(sec);
        if (!finalMessage)
            clickToContinue.text = "(Press any key to continue)";
        swapText = true;
    }   
}
