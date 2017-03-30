using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour {

    public HexGrid hexgrid;
    private Color mouseOverColor = new Color(1, 0, 0, 0.4f);
    private Color originalColor;
    private bool dragging = false;
    private float distance;
    private int oldIndex = 0;

    private List<Vector3> cellPositions;
    private Renderer renderer;

    public Vector3 globalPosition;
    public bool stayedInSameSpot;

    public Animator animator;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }
    
    // Use this for initialization
    void Start () {
        HexCell[] cells = hexgrid.cells;
        cellPositions = new List<Vector3>();
        foreach (HexCell c in cells)
        {
            if (c != null) // skip the null cells (to make symmetrical board)
                cellPositions.Add(c.transform.position);
        }
        PinPosition();
        stayedInSameSpot = false;
        animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        renderer.material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        renderer.material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        animator.SetBool("Dragging", true);
    }

    void OnMouseUp()
    {
        Vector3 oldPosition = globalPosition;
        PinPosition();
        Vector3 newPosition = globalPosition;
        
        //set back to false in RoundCounter
        if (oldPosition == newPosition)
            stayedInSameSpot = true;    
    }
    // Update is called once per frame
    void Update () {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, 150f, rayPoint.z);
        }
    }

    void PinPosition()
    {
        hexgrid.occupiedCells[oldIndex] = 0;
        dragging = false;
        animator.SetBool("Dragging", false);

        Vector3 currentPosition = transform.position;

        Vector3 closetCell = new Vector3(0, 0, 0);
        float dist = float.MaxValue;
        int index = 0;
        for (int i = 0; i < cellPositions.Count; i++)
        {
            Vector3 v = cellPositions[i];

            if (Vector3.Distance(v, currentPosition) < dist && hexgrid.occupiedCells[i] == 0)
            {
                dist = Vector3.Distance(v, currentPosition);
                closetCell = v;
                index = i;
            }
        }
        transform.position = new Vector3(closetCell.x, 0f, closetCell.z);
        hexgrid.occupiedCells[index] = 1;
        oldIndex = index;

        globalPosition = transform.position;
    }
}
