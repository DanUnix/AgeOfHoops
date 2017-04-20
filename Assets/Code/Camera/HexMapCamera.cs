// Source: http://catlikecoding.com/unity/tutorials/hex-map/part-5/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapCamera : MonoBehaviour {

    Transform swivel, stick;
    float zoom = 1f;
    public float stickMinZoom = -320, stickMaxZoom = -100;
    public float swivelMinZoom = 90, swivelMaxZoom = 45;
    public float moveSpeedMinZoom = 500, moveSpeedMaxZoom = 200;
    public float rotationSpeed = 180;
    public float rotationAngle = 0;

    public HexGrid grid;
    public ScoreController score;

    //cutscene states
    // 0 = open
    // 1 = play
    // 2 = win
    private int state;
    public GameObject winner;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private Vector3 look;
    private Vector3 startLook;
    private Vector3 winnerPos;
    private bool setup;
    private Vector3 camPos;

    void Awake()
    {
        swivel = transform.GetChild(0);
        stick = swivel.GetChild(0);
    }

    // Use this for initialization
    void Start () {
        state = 0;
        look = winner.transform.position;
        look.x -= 100;
        look.y += 120;
        startLook = winner.transform.position;
        startLook.x += 200;
        startLook.y += 120;
        startTime = Time.time;
        camPos = Camera.main.transform.position;
        journeyLength = Vector3.Distance(startLook, camPos);
        Camera.main.transform.position = startLook;
    }
	
	// Update is called once per frame
	void Update () {
        if(state == 0)
        {
            winnerPos = winner.transform.position;
            winnerPos.y += 100;
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, camPos, fracJourney);
            Camera.main.transform.LookAt(winnerPos, Vector3.up);
            if (Camera.main.transform.position.y > camPos.y - 10)
            {
                Camera.main.transform.position = camPos;
                //Camera.main.transform.rotation.;
                state++;
            }
        }

        else if (state == 1)
        {
            float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
            if (zoomDelta != 0f)
            {
                AdjustZoom(zoomDelta);
            }

            float xDelta = Input.GetAxis("Horizontal");
            float zDelta = Input.GetAxis("Vertical");
            if (xDelta != 0f || zDelta != 0f)
            {
                AdjustPosition(xDelta, zDelta);
            }
            float rotationDelta = Input.GetAxis("Rotation");
            if (rotationDelta != 0f)
            {
                AdjustRotation(rotationDelta);
            }

            if(score.playerScore >= score.winScore)
            {
                state++;
                journeyLength = Vector3.Distance(Camera.main.transform.position, look);
            }
        }
        
        else if(state == 2)
        {
            winnerPos = winner.transform.position;
            winnerPos.y += 100;
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, look, fracJourney);
            Camera.main.transform.LookAt(winnerPos, Vector3.up);

            if (Camera.main.transform.position.y < look.y + 10)
                score.gameFlow.triggerVictory();
        }
    }

    void AdjustRotation(float delta)
    {
        rotationAngle += delta * rotationSpeed * Time.deltaTime;
        if (rotationAngle < 0f)
        {
            rotationAngle += 360f;
        }
        else if (rotationAngle >= 360f)
        {
            rotationAngle -= 360f;
        }
        transform.localRotation = Quaternion.Euler(0f, rotationAngle, 0f);

    }


    void AdjustZoom(float delta)
    {
        zoom = Mathf.Clamp01(zoom + delta);

        float distance = Mathf.Lerp(stickMinZoom, stickMaxZoom, zoom);
        stick.localPosition = new Vector3(0f, 0f, distance);

        float angle = Mathf.Lerp(swivelMinZoom, swivelMaxZoom, zoom);
        swivel.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }


    void AdjustPosition(float xDelta, float zDelta)
    {
        Vector3 direction = transform.localRotation * new Vector3(xDelta, 0f, zDelta).normalized;
        float damping = Mathf.Max(Mathf.Abs(xDelta), Mathf.Abs(zDelta));
        float distance = Mathf.Lerp(moveSpeedMinZoom, moveSpeedMaxZoom, zoom)
            * damping * Time.deltaTime;

        Vector3 position = transform.localPosition;
        position += direction * distance;
        transform.localPosition = position;
    }
    
}
