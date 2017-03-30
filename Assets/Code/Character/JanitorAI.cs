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
    private float acceleration;

    public Rigidbody rb;

    private bool reversed = false;
    private Vector3 upVector;
    private Vector3 rightVector;

    private float coolDownTime;
    private int timesSpedUp;
    private bool changeAcceleration;

    private float breakTimer;
    private bool onBreak;

    private float restingTime;

	// Use this for initialization
	void Start () {
        timesSpedUp = 0;
        movespeed = 50f;
        acceleration = 0.5f;
        changeAcceleration = false;

        onBreak = false;
        breakTimer = 15.0f;
        restingTime = 0;
        rb = GetComponent<Rigidbody>();
        upVector = new Vector3(0, 0, -1 * movespeed);
        rightVector = new Vector3(-1 * movespeed, 0, 0);
        //rb.velocity = rightVector;
        rb.AddForce(rightVector * rb.mass);
    }
	
	// Update is called once per frame
	void Update () {

        if (JanitorBreak())
            return;

        SetMovement();

        //old code
        //if (transform.position.x <= -557 && transform.position.z >= 311)
        //{
        //    rb.velocity = reversed ? -1 * rightVector : upVector;
        //}
        //else if (transform.position.x <= -557 && transform.position.z <= -311)
        //{
        //    rb.velocity = reversed ? -1 * upVector : -1 * rightVector;
        //}
        //else if (transform.position.x >= 557 && transform.position.z <= -311)
        //{
        //    rb.velocity = reversed ? rightVector : -1 * upVector;
        //}
        //else if (transform.position.x >= 557 && transform.position.z >= 311) {
        //    rb.velocity = reversed ? upVector : rightVector;
        //}

        coolDownTime -= Time.deltaTime;
        if (coolDownTime <= 0 && timesSpedUp > 0) {
            //rb.velocity /= 2;
            acceleration /= 2;
            upVector = new Vector3(0, 0, -1 * movespeed);
            rightVector = new Vector3(-1 * movespeed, 0, 0);

            timesSpedUp -= 1;
            if (timesSpedUp > 0) {
                coolDownTime = 7.5f;
            }
        }
	}

    void OnMouseEnter() {
        //rb.velocity *= -2;
        timesSpedUp += 1;
        reversed = reversed ? false : true;

        if (timesSpedUp < 4)
        {
            changeAcceleration = true;
            movespeed *= 2;
        }

        upVector = new Vector3(0, 0, -1 * movespeed);
        rightVector = new Vector3(-1 * movespeed, 0, 0);
        coolDownTime = 7.5f;
    }

    bool JanitorBreak()
    {
        if (onBreak == false && timesSpedUp == 0)
        {
            breakTimer -= Time.deltaTime;
            //time to go on break
            if (breakTimer <= 0 && InCorner())
            {
                onBreak = true;
                rb.velocity = new Vector3(0, 0, 0);
                restingTime = 0f;
                return true;
            }
            return false;
        }
        else if (onBreak == true && restingTime <= 8.0f)
        {
            restingTime += Time.deltaTime;
            return true;
        }
        else if (onBreak == true && restingTime > 8.0f) {
            onBreak = false;
            restingTime = 0f;
            breakTimer = 15.0f;
            return false;
        }
        return false;
    }

    bool InCorner()
    {
        if (transform.position.x <= -557 && transform.position.z >= 311)
        {
            return true;
        }
        else if (transform.position.x <= -557 && transform.position.z <= -311)
        {
            return true;
        }
        else if (transform.position.x >= 557 && transform.position.z <= -311)
        {
            return true;
        }
        else if (transform.position.x >= 557 && transform.position.z >= 311)
        {
            return true;
        }

        return false;
    }

    void SetMovement()
    {
        //corners movement
        if (transform.position.x <= -557 && transform.position.z >= 311)
        {
            if (changeAcceleration)
            {
                changeAcceleration = false;
                acceleration *= 10;
            }
            rb.velocity = reversed ? -1 * rightVector : upVector;
            return;
        }
        else if (transform.position.x <= -557 && transform.position.z <= -311)
        {
            if (changeAcceleration)
            {
                changeAcceleration = false;
                acceleration *= 10;
            }
            rb.velocity = reversed ? -1 * upVector : -1 * rightVector;
            return;
        }
        else if (transform.position.x >= 557 && transform.position.z <= -311)
        {
            if (changeAcceleration)
            {
                changeAcceleration = false;
                acceleration *= 10;
            }
            rb.velocity = reversed ? rightVector : -1 * upVector;
            return;
        }
        else if (transform.position.x >= 557 && transform.position.z >= 311)
        {
            if (changeAcceleration)
            {
                changeAcceleration = false;
                acceleration *= 10;
            }
            rb.velocity = reversed ? upVector : rightVector;
            return;
        }


        //middle of the court movement
        if (transform.position.x > -556 && transform.position.x <= 0)
        {
            if (transform.position.z <= -311)
            {
                rb.velocity += reversed ? new Vector3(acceleration, 0, 0) : new Vector3(acceleration, 0, 0);
            }
            else if (transform.position.z >= 311)
            {
                rb.velocity += reversed ? new Vector3(acceleration, 0, 0) : new Vector3(acceleration, 0, 0);
            }
        }
        else if (transform.position.x > 0 && transform.position.x <= 556)
        {
            if (transform.position.z <= -311)
            {
                rb.velocity += new Vector3(-acceleration, 0, 0);
            }
            else if (transform.position.z >= 311)
            {
                rb.velocity += new Vector3(-acceleration, 0, 0);
            }
        }
        else if (transform.position.z > -310 && transform.position.z <= 0)
        {
            if (transform.position.x <= -557)
            {
                rb.velocity += new Vector3(0, 0, acceleration);
            }
            else if (transform.position.x >= 557)
            {
                rb.velocity += new Vector3(0, 0, acceleration);
            }
        }
        else if (transform.position.z > 0 && transform.position.z <= 310)
        {
            if (transform.position.x <= -557)
            {
                rb.velocity += new Vector3(0, 0, -acceleration);
            }
            else if (transform.position.x >= 557)
            {
                rb.velocity += new Vector3(0, 0, -acceleration);
            }
        }
    }
}
