//Source: http://blog.infrared5.com/2013/07/trajectory-of-a-basketball-in-unity3d/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {

    // The position of the hoop for the ball to direct towards
    public GameObject hoopPosition;

    // The targetPosition
    private Vector3 targetPosition;
    // The basketball object
    public GameObject basketball;

    // Boolean value that status is based on the ball being shot
    public bool ballShot;
    public bool locked;

    private float multiplier = 15;

    
    
    // When ball enters the hoop score counter increases

    // Use this for initialization
    void Start () {
        targetPosition = hoopPosition.transform.position;
        Physics.gravity *= multiplier;

        ballShot = false;
        locked = false;
    }
	
	// Update is called once per frame
	void Update () {

        // Spacebar to shoot the ball
        bool down = Input.GetKeyDown(KeyCode.Space);
        
        if (down && ballShot == false && !locked)
        {
            // Create basketball object at character's position
            var ball = GameObject.Instantiate(basketball, this.transform.position + this.transform.up, Quaternion.identity) as GameObject;
            Vector3 temp = new Vector3(0,50,0);
            ball.transform.position += temp;
            // Ignore ball on character collision
            var ballCollider = this.GetComponentInChildren<Collider>();
            Physics.IgnoreCollision(ball.GetComponent<Collider>(), ballCollider);
            
            // give the correct initial velocity so the ball arcs into the target
            Vector3 newVel = findInitialVelocity(ball.transform.position, targetPosition);
            //Debug.Log("newVel: (" + newVel.x.ToString(".00") +", " + newVel.y.ToString(".00") +", "+ newVel.z.ToString(".00") +")");

            // set the new velocity on the rigid body

            ball.GetComponent<Rigidbody>().velocity = newVel;
            // unfreeze the rigid body
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            ball.GetComponent<Rigidbody>().WakeUp();
            ballShot = true;
            Destroy(ball, 15f);

        }
    }
    

    private Vector3 findInitialVelocity(Vector3 startPosition, Vector3 finalPosition, float maxHeightOffset = 0.6f, float rangeOffSet = 0.11f)
    {
        // get our return value ready. Default to (0f, 0f, 0f)
        Vector3 newVel = new Vector3();

        // Find the direction vector without the y-component
        
        Vector3 direction = new Vector3(finalPosition.x, 0f, finalPosition.z) - new Vector3(startPosition.x, 0f, startPosition.z);
        // Find the distance between the two points (without the y-component)
        float range = direction.magnitude;

        // Add a little bit to the range so that the ball is aiming at hitting the back of the rim.
        // Back of the rim shots have a better chance of going in.
        // This accounts for any rounding errors that might make a shot miss (when we don't want it to).
        range += rangeOffSet;

        // Find unit direction of motion without the y component
        Vector3 unitDirection = direction.normalized;

        // Find the max height
        // Start at a reasonable height above the hoop, so short range shots will have enough clearance to go in the basket
        // without hitting the front of the rim on the way up or down.
        float maxYPos = targetPosition.y + maxHeightOffset;

        // check if the range is far enough away where the shot may have flattened out enough to hit the front of the rim
        // if it has, switch the height to match a 45 degree launch angle
        if (range / 2f >= maxYPos)
		{
            maxYPos = range / 2f;
        }

        // find the initial velocity in y direction
        newVel.y = Mathf.Sqrt(-2.0f * Physics.gravity.y * (maxYPos - startPosition.y));

        // find the total time by adding up the parts of the trajectory
        // time to reach the max
        float timeToMax = Mathf.Sqrt(-2.0f * (maxYPos - startPosition.y) / Physics.gravity.y);

        // time to return to y-target
        float timeToTargetY = Mathf.Sqrt(-2.0f * (maxYPos - finalPosition.y) / Physics.gravity.y);

        // add them up to find the total flight time
        float totalFlightTime = timeToMax + timeToTargetY;

        // find the magnitude of the initial velocity in the xz direction
        float horizontalVelocityMagnitude = range / totalFlightTime;

        // use the unit direction to find the x and z components of initial velocity
        newVel.x = horizontalVelocityMagnitude * unitDirection.x;
        newVel.z = horizontalVelocityMagnitude * unitDirection.z;

        return newVel;
    }
}
