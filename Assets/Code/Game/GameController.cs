using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public HexGrid hexgrid;

	// Use this for initialization
	void Start () {       
    }
	
	// Update is called once per frame
	void Update () {
        if (hexgrid.occupiedCells[((hexgrid.height / 2) * hexgrid.width) - 1] == 1)
        {
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
	}
}
