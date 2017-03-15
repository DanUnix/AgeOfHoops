using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
JanitorAI

All Original Code

The AI for the Janitor lets the janitor character move around with an intial velocity

If the janitor is interrupted by the player's mouse it increases its speed and moves in the opposite direction

After 7.5 seconds of not being interrupted the janitor will then decrease its speed and return to its

intial velocity. 
*/
public class JanitorAI : MonoBehaviour {

    private float movespeed;

    public Rigidbody rb;

    private bool reversed = false;
    private Vector3 upVector;
    private Vector3 rightVector;

    private float coolDownTime;
    private int timesSpedUp;
	// Use this for initialization
	void Start () {
        timesSpedUp = 0;
        movespeed = 100f;
        rb = GetComponent<Rigidbody>();
        upVector = new Vector3(0, 0, -1 * movespeed);
        rightVector = new Vector3(-1 * movespeed, 0, 0);
        rb.velocity = rightVector;
    }
	
	// Update is called once per frame
	void Update () {

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
}
