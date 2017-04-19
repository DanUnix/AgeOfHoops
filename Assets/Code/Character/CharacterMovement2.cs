using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour {

    public HexGrid hexgrid;
    private Color mouseOverColor = new Color(1, 0, 0, 0.4f);
    private Color originalColor;
    private bool dragging = false;
    private float distance;
    public int oldIndex;

    private List<Vector3> cellPositions;
    private Renderer renderer;

    public Vector3 globalPosition;
    public bool stayedInSameSpot;
    public bool movedThisRound;

    public bool moved;
    public Animator animator;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        moved = false;
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
        movedThisRound = false;
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
        if (!movedThisRound)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
            animator.SetBool("Dragging", true);
        }
    }

    void OnMouseUp()
    {
        if (!movedThisRound)
        {
            Vector3 oldPosition = globalPosition;
            PinPosition();
            Vector3 newPosition = globalPosition;

            //set back to false in RoundCounter
            if (oldPosition == newPosition && moved)
                stayedInSameSpot = true;

            movedThisRound = true;
        }   
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
        moved = false;
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


        if (!validMove(index))
        {
            Vector3 oldPosition = cellPositions[oldIndex];
            transform.position = new Vector3(oldPosition.x, 0f, oldPosition.z);
            hexgrid.occupiedCells[oldIndex] = 1;
            globalPosition = transform.position;
            moved = false;
            return;
        }


        transform.position = new Vector3(closetCell.x, 0f, closetCell.z);
        hexgrid.occupiedCells[index] = 1;
        oldIndex = index;

        globalPosition = transform.position;
        moved = true;
    }


    public void resetPosition()
    {

    }



    bool validMove(int newindex)
    {
        if ((oldIndex - newindex) == 0) //stay in same spot
        {
            return true;
        }
        else if ((oldIndex - newindex) == 1) //move left
        {
            if (oldIndex == 30 || oldIndex == 23 || oldIndex == 15
                || oldIndex == 8 || oldIndex == 0)
                return false;
            else
                return true;
        }
        else if ((oldIndex - newindex) == -1) //move right
        {
            if (oldIndex == 29 || oldIndex == 22
                || oldIndex == 14 || oldIndex == 7)
                return false;
            else
                return true;
        }
        else if ((oldIndex - newindex) == 7) //move down right
        {
            if (oldIndex == 37 || oldIndex == 22 || //right edges
                (oldIndex >= 0 && oldIndex <= 7)) // bottom row
                return false;
            else
                return true;
        }
        else if ((oldIndex - newindex) == -8) //move up right
        {
            if (oldIndex == 7 || oldIndex == 22 || // right edges
                (oldIndex >= 30 && oldIndex <= 37)) // top row
                return false;
            else
                return true;
        }
        else if ((oldIndex - newindex) == 8) //move down left
        {
            if (oldIndex == 30 || oldIndex == 15 || // left edges
                (oldIndex >= 0 && oldIndex <= 7)) // bottom row
                return false;
            else
                return true;
        }
        else if ((oldIndex - newindex) == -7) //move up left
        {
            if (oldIndex == 0 || oldIndex == 15 || // left edges
                (oldIndex >= 30 && oldIndex <= 37)) // top row
                return false;
            else
                return true;
        }
        else
        {
            return false;
        }

    }
}
