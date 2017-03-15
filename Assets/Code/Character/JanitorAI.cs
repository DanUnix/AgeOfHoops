using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
JanitorAI

All Original Code

The AI for the Janitor lets the janitor character move around with an intial velocity

If the janitor is interrupted by the player's mouse it increases its speed and moves in the opposite direction

After 7.5 seconds of not being interrupted the janitor will then decrease its speed and return to its intial velocity. 

The janitor takes a break every 20s when not interrupted and continues afterwards 
*/
public class JanitorAI : MonoBehaviour {

    private float movespeed;

    public Rigidbody rb;

    private bool reversed = false;
    private Vector3 upVector;
    private Vector3 rightVector;
    private Vector3 preBreakVector;

    private float coolDownTime;
    private int timesSpedUp;

    private float breakTimer;
    private bool onBreak;

    private float restingTime;

	// Use this for initialization
	void Start () {
        timesSpedUp = 0;
        movespeed = 100f;
        onBreak = false;
        breakTimer = 20.0f;
        restingTime = 0;
        rb = GetComponent<Rigidbody>();
        upVector = new Vector3(0, 0, -1 * movespeed);
        rightVector = new Vector3(-1 * movespeed, 0, 0);
        rb.velocity = rightVector;
    }
	
	// Update is called once per frame
	void Update () {

        JanitorBreak();

        if (transform.position.x <= -557 && transform.position.z >= 311)
        {
            rb.velocity = reversed ? -1 * rightVector : upVector;
        }
        else if (transform.position.x <= -557 && transform.position.z <= -311)
        {
            rb.velocity = reversed ? -1 * upVector : -1 * rightVector;
        }
        else if (transform.position.x >= 557 && transform.position.z <= -311)
        {
            rb.velocity = reversed ? rightVector : -1 * upVector;
        }
        else if (transform.position.x >= 557 && transform.position.z >= 311) {
            rb.velocity = reversed ? upVector : rightVector;
        }

        coolDownTime -= Time.deltaTime;
        if (coolDownTime <= 0 && timesSpedUp > 0) {
            rb.velocity /= 2;
            movespeed /= 2;
            upVector = new Vector3(0, 0, -1 * movespeed);
            rightVector = new Vector3(-1 * movespeed, 0, 0);

            timesSpedUp -= 1;
            if (timesSpedUp > 0) {
                coolDownTime = 7.5f;
            }
        }
	}

    void OnMouseEnter() {
        rb.velocity *= -2;
        movespeed *= 2;
        reversed = reversed ? false : true;
        upVector = new Vector3(0, 0, -1 * movespeed);
        rightVector = new Vector3(-1 * movespeed, 0, 0);
        timesSpedUp += 1;
        coolDownTime = 7.5f;
    }

    void JanitorBreak()
    {
        if (onBreak == false && timesSpedUp == 0)
        {
            breakTimer -= Time.deltaTime;
        }
        if (breakTimer <= 0 && onBreak == false && timesSpedUp == 0)
        {
            onBreak = true;
            preBreakVector = rb.velocity;
            rb.velocity = new Vector3(0, 0, 0);
            restingTime = 0f;
        }
        if (onBreak == true && restingTime <= 10.0f)
        {
            restingTime += Time.deltaTime;
        }
        else if (onBreak == true && restingTime > 10.0f) {
            onBreak = false;
            restingTime = 0f;
            rb.velocity = preBreakVector;
            breakTimer = 20.0f;
        }
    }
}
