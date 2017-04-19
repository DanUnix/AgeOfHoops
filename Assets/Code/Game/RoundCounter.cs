using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour {

    // Round label that will hold text of incrementing round
    public Text roundLabel;

    public Timer gameTimer;
    public ScoreController gameScore;
    private int oldAIScore, oldPlayerScore;

    // Counter for number of rounds
    public int roundCounter;

    // 3 character objects
    public CharacterMovement2 p1;
    public CharacterMovement2 p2;
    public CharacterMovement2 p3;

    public FollowAI Aomine;
    public DennisHotrodman dennisHotrodman;
  

    // Keep track of ball Shot
    public ShootBall myBallStatus;
   
    // Use this for initialization
	void Start () {
        setOldScores();

        this.roundCounter = 1;
        roundLabel.text = "Round: 1";
	}
	
	// Update is called once per frame
	void Update () {
     
        if (allCharactersMoved())
        {
            updateRoundLabel();

            // When round is incremented make the ball shootable again.
            myBallStatus.ballShot = false;
        }

        if (myBallStatus.ballShot == true)
        {
            myBallStatus.ballShot = false;
            StartCoroutine(waitForBall());
        }
               
	}

    public int getRoundCounter()
    {
        return this.roundCounter;
    }

    public void updateRoundLabel()
    {
        gameTimer.resetTimer();
        roundCounter += 1;

        if (roundCounter > 10)
            resetRoundCounter();

        roundLabel.text = "Round: " + roundCounter;
        markCharactersMovable();
    }

    void resetRoundCounter()
    {
        gameScore.aiScore += 1;
        roundCounter = 0;

        resetCharacters();

    }

    void setOldScores()
    {
        oldAIScore = gameScore.aiScore;
        oldPlayerScore = gameScore.playerScore;
    }

    void resetCharacters()
    {
        p1.resetPosition();
        p2.resetPosition();
        p3.resetPosition();

        Aomine.resetPosition();
        dennisHotrodman.resetPosition();
    }


    bool allCharactersMoved()
    {
        return (p1.movedThisRound || p1.stayedInSameSpot)
            && (p2.movedThisRound || p2.stayedInSameSpot)
            && (p3.movedThisRound || p3.stayedInSameSpot);
    }

    void markCharactersMovable()
    {
        p1.movedThisRound = false;
        p2.movedThisRound = false;
        p3.movedThisRound = false;
    }

    IEnumerator waitForBall()
    {
        yield return new WaitForSeconds(4);
        updateRoundLabel();
        resetCharacters();
    }
}
