using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Color mouseOverColor = new Color(1, 0, 0, 0.4f);
    private Color originalColor;
    private bool dragging = false;
    private float distance;
    

    private Renderer renderer;

    void Awake() {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }
    void OnMouseEnter() {
        renderer.material.color = mouseOverColor;
    }

    void OnMouseExit() {
        renderer.material.color = originalColor;
    }

    void OnMouseDown() {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    void OnMouseUp() {
        dragging = false;
        GetComponent<CapsuleCollider>().enabled = true;
    }
	// Use this for initialization
	void Start () {
        
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (dragging) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, 40.5f, rayPoint.z);          
        }
	}

    void OnTriggerEnter(Collider cell)
    {
        if(cell.tag == "hexcell")
            transform.position = new Vector3(cell.transform.position.x, 40.5f, cell.transform.position.z);
    }
}
