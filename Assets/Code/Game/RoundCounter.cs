using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {

    // Round label that will hold text of incrementing round
    public Text roundLabel;

    // Counter for number of rounds
    public int roundCounter = 1;

    // 3 character objects
    public CharacterMovement2 myCharacter;
    public CharacterMovement2 mc2;
    public CharacterMovement2 mc3;
   
    // Old positions of the 3 characteres
    private Vector3 oldPosition;
    private Vector3 oldPosition2;
    private Vector3 oldPosition3;

    // Keep track of ball Shot
    public ShootBall myBallStatus;
   
    // Use this for initialization
	void Start () {
        oldPosition = myCharacter.globalPosition;
        roundLabel.text = "Round: 1";
	}
	
	// Update is called once per frame
	void Update () {


     
        if ((myCharacter.globalPosition != oldPosition)
            && (mc2.globalPosition != oldPosition2 )
            && (mc3.globalPosition != oldPosition3))
        {
            
            roundCounter += 1;
            roundLabel.text = "Round: " + roundCounter.ToString();
            oldPosition = myCharacter.globalPosition;
            oldPosition2 = mc2.globalPosition;
            oldPosition3 = mc3.globalPosition;
            // When round is incremented make the ball shootable again.
            
            myBallStatus.ballShot = false;
        }
               
	}

    public int getRoundCounter()
    {
        return roundCounter;
    }
}
