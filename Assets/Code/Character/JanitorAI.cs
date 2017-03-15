using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorAI : MonoBehaviour {

    public float movespeed = 100f;

    public Rigidbody rb;

    private bool reversed = false;
    private Vector3 upVector;
    private Vector3 rightVector;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        upVector = new Vector3(0, 0, -1 * movespeed);
        rightVector = new Vector3(-1 * movespeed, 0, 0);
        rb.velocity = rightVector;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            rb.velocity *= -1;
            reversed = reversed ? false : true;
            
        }
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
	}
}
