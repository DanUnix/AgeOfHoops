using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    public CharacterMovement2 kuroko;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        transform.Rotate(90, 0, 0);

        Vector3 k = kuroko.transform.position;
        transform.position = new Vector3(k.x, k.y + 140, k.z);
    }
}
