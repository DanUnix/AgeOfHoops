using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScene : MonoBehaviour {

    public Text uiText;
    float timer;
    private Font customFont;

    AudioSource music;
    private float startVolume;

    // Use this for initialization
    void Start () {
        timer = 0;
        customFont = uiText.font;

        music = GetComponent<AudioSource>();
        startVolume = music.volume;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 45)
            Application.Quit();
        else if (timer >= 40)
        {
            uiText.font = customFont;
            uiText.fontSize = 80;
            uiText.alignment = TextAnchor.MiddleCenter;
            uiText.text = "~Bye Felicia~";
            music.volume -= startVolume * Time.deltaTime / 5;
        }
        else if (timer >= 25)
            uiText.text = "Song credits:\n\n" +
            "\"Great Days\" by Yugo Kanno ft. Karen Aoki & Daisuke Hasegawa\n" +
            "      (JoJo's Bizarre Adventure: Diamond is Unbreakable OST)\n" +
            "\"Time to Attack\" by Santa (Jormungand Original Soundtrack)\n" +
            "\"Bububu\" by REDALiCE (REDSHIFT)\n" +
            "\"DREAM×SCRAMBLE!\" by AiRI (Keijo!!!!!!!! OST)";
        else if (timer >= 10)
        {
            uiText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            uiText.fontSize = 30;
            uiText.alignment = TextAnchor.MiddleLeft;
            uiText.text = "Game by:\n\n" +
            "   Alan Fan (lead designer a.k.a. main monkey)\n" +
            "   Jae Jeon (program manager a.k.a. box me n00b)\n" +
            "   Daniel Pulley (game developer a.k.a. git 'over here' master)";
        }
        else if (timer >= 5)
            uiText.text = "Thanks for playing!";
        else
            uiText.text = "You win!\nCongratulations, you're not boosted!";

    }

}
