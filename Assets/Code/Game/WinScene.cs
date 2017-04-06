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

        if (timer >= 95)
            Application.Quit();
        else if (timer >= 90)
        {
            uiText.text = "~Bye Felicia~";
            music.volume -= startVolume * Time.deltaTime / 5;
        }
        else if (timer >= 85)
        {
            uiText.font = customFont;
            uiText.fontSize = 80;
            uiText.alignment = TextAnchor.MiddleCenter;
            uiText.text = "Thanks for playing!";
        }
        else if (timer >= 80)
            uiText.text = "Song credits:\n\n" +
            "\"Great Days\" by Yugo Kanno ft. Karen Aoki & Daisuke Hasegawa\n" +
            "      (JoJo's Bizarre Adventure: Diamond is Unbreakable OST)\n" +
            "\"Time to Attack\" by Santa (Jormungand Original Soundtrack)\n" +
            "\"Bububu\" by REDALiCE (REDSHIFT)\n" +
            "\"DREAM×SCRAMBLE!\" by AiRI (Keijo!!!!!!!! OST)";
        else if (timer >= 65)
        {
            uiText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            uiText.fontSize = 30;
            uiText.alignment = TextAnchor.MiddleLeft;
            uiText.text = "Game by:\n\n" +
            "   Alan Fan (lead designer a.k.a. main monkey)\n" +
            "   Jae Jeon (program manager a.k.a. box me n00b)\n" +
            "   Daniel Pulley (game developer a.k.a. git 'over here' master)";
        }
        else if (timer >= 55)
            uiText.text = "But in the meantime, enjoy this music and\n" +
                "listing of sources used in this game!";
        else if (timer >= 50)
            uiText.text = "Look forward to our next release for more content!";
        else if (timer >= 45)
            uiText.text = "But we're not...hehehe";
        else if (timer >= 40)
            uiText.text = "Now you're ready for the boss!";
        else if (timer >= 35)
            uiText.text = "How embarassing would've it had been if you didn't...";
        else if (timer >= 30)
            uiText.text = "Thank goodness you were able to beat the tutorial...";
        else if (timer >= 25)
            uiText.text = "A.K.A. Jong-Unny, supreme leader of your worst nightmare!";
        else if (timer >= 15)
            uiText.text = "\"This isn't the last of me!\" he screams as he limps\n" +
                "into his private jet to get help from his best friend Kimmy.";
        else if (timer >= 10)
        {
            uiText.text = "You have successfully befuddled Dennis Hotrodman";
        }
        else if (timer >= 5)
        {
            uiText.fontSize = 70;
            uiText.text = "Congratulations, you're not boosted!";
        }
        else
            uiText.text = "You win!";

    }

}
