using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {

    // Round label that will hold text of incrementing round
    public Text roundLabel;

    public Timer gameTimer;

    // Counter for number of rounds
    public int roundCounter;

    // 3 character objects
    public CharacterMovement2 p1;
    public CharacterMovement2 p2;
    public CharacterMovement2 p3;
   
    // Old positions of the 3 characteres
    private Vector3 oldPosition1;
    private Vector3 oldPosition2;
    private Vector3 oldPosition3;

    // Keep track of ball Shot
    public ShootBall myBallStatus;
   
    // Use this for initialization
	void Start () {
        setPositions();

        this.roundCounter = 1;
        roundLabel.text = "Round: 1";
	}
	
	// Update is called once per frame
	void Update () {
     
        if ((p1.globalPosition != oldPosition1)
            && (p2.globalPosition != oldPosition2 )
            && (p3.globalPosition != oldPosition3))
        {
            
            
            updateRoundLabel();
            setPositions();
            // When round is incremented make the ball shootable again.
            
            myBallStatus.ballShot = false;
        }
               
	}

    void setPositions()
    {
        oldPosition1 = p1.globalPosition;
        oldPosition2 = p2.globalPosition;
        oldPosition3 = p3.globalPosition;
    }

    public int getRoundCounter()
    {
        return this.roundCounter;
    }

    public void updateRoundLabel()
    {
        gameTimer.resetTimer();
        roundCounter += 1;
        roundLabel.text = "Round: " + roundCounter.ToString();
    }
}
