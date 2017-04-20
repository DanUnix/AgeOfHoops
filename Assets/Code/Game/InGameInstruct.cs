using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameInstruct : MonoBehaviour {


    public Canvas instructMenu;
    public Button exitText;

    // Use this for initialization
    void Start () {
        instructMenu = instructMenu.GetComponent<Canvas>();
        instructMenu.enabled = false;
        exitText = exitText.GetComponent<Button>();
        exitText.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I)) {
            instructMenu.enabled = true;
        }
       
    }

    public void ExitPress()
    {
        instructMenu.enabled = true;
        exitText.enabled = false;


    }

    public void noPress()
    {
        instructMenu.enabled = false;
        exitText.enabled = true;

    }
}
