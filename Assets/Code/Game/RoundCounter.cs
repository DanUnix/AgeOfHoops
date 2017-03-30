using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {

    public Text roundLabel;

    public int roundCounter = 1;

    public CharacterMovement2 myCharacter;

    private Vector3 oldPosition;
	// Use this for initialization
	void Start () {
        oldPosition = myCharacter.globalPosition;
        roundLabel.text = "Round: 1";
	}
	
	// Update is called once per frame
	void Update () {
        
        if (myCharacter.globalPosition != oldPosition || myCharacter.stayedInSameSpot == true)
        {
            roundCounter += 1;
            roundLabel.text = "Round: " + roundCounter.ToString();
            oldPosition = myCharacter.globalPosition;
            if (myCharacter.stayedInSameSpot == true)
                myCharacter.stayedInSameSpot = false;
        }
	}

    public int getRoundCounter()
    {
        return roundCounter;
    }
}
