using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorAI : MonoBehaviour {

    public float movespeed = 100f;

    public Rigidbody rb;


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-1 * movespeed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= -557 && transform.position.z >= 311)
        {
            rb.velocity = new Vector3(0, 0, -1 * movespeed);
        }
        else if (transform.position.x <= -557 && transform.position.z <= -311)
        {
            rb.velocity = new Vector3(movespeed, 0, 0);
        }
        else if (transform.position.x >= 557 && transform.position.z <= -311)
        {
            rb.velocity = new Vector3(0, 0, movespeed);
        }
        else if (transform.position.x >= 557 && transform.position.z >= 311) {
            rb.velocity = new Vector3(-1 * movespeed, 0, 0);
        }
	}
}
