using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour {

    public Canvas ExitMenu;
    public Button yesButton;
    public Button noButton;

	// Use this for initialization
	void Start () {
	    ExitMenu = ExitMenu.GetComponent<Canvas>();
        ExitMenu.enabled = false;
        yesButton = yesButton.GetComponent<Button>();
        noButton = noButton.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitMenu.enabled = true;
        }
    }

    public void ExitPress()
    {
        ExitMenu.enabled = true;
        yesButton.enabled = false;
        noButton.enabled = false;


    }

    public void noPress()
    {
        ExitMenu.enabled = false;
        yesButton.enabled = true;
        noButton.enabled = true;

    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);        
    }
}
