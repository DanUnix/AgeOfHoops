using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructMenu : MonoBehaviour {

    public MainMenuScript ms;

    public Canvas instructMenu;
    public Button controlText;
    public Button exitText;
     
    // Use this for initialization
    void Start () {

        instructMenu = instructMenu.GetComponent<Canvas>();
        instructMenu.enabled = false;
        exitText = exitText.GetComponent<Button>();
        controlText = ms.controlText;
        controlText = controlText.GetComponent<Button>();
        exitText.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitPress()
    {
        instructMenu.enabled = true;
        controlText.enabled = false;
        
       
    }

    public void noPress()
    {
        instructMenu.enabled = false;
        controlText.enabled = true;
        exitText.enabled = true;
       
    }

    public void hideInstructions()
    {
        instructMenu.enabled = false;
    }
}
