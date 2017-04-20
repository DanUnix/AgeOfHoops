using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button loadText;
    public Button controlText;
    public Button exitText;

    private bool isShowing;

	// Use this for initialization
	void Start () {

        isShowing = false;
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        controlText = controlText.GetComponent<Button>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        controlText.enabled = false;
    }

    public void noPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        controlText.enabled = true;
    }

    public void StartLevel()
    {

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
