using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {

    public Text roundLabel;

    public int roundCounter = 1;

    public CharacterMovement2 myCharacter;
    public CharacterMovement2 mc2;
    public CharacterMovement2 mc3;
   

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
            //if (myCharacter.stayedInSameSpot == true)
            //    myCharacter.stayedInSameSpot = false;
           // if (mc2.stayedInSameSpot == true)
           //     mc2.stayedInSameSpot = false;
            //if (mc3.stayedInSameSpot == true)
            //    mc3.stayedInSameSpot = false;

            // When round is incremented make the ball shootable again.
            
            myBallStatus.ballShot = false;
        }
               
	}

    public int getRoundCounter()
    {
        return roundCounter;
    }
}
