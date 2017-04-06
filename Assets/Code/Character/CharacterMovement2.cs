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
        if (oldPosition == newPosition && moved)
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


    bool validMove(int newindex)
    {
        if (oldIndex == 0)
        {
            if (newindex == 0 || newindex == 1 || newindex == 8)
                return true;
        }
        else if (oldIndex == 15)
        {
            if (newindex == 15 || newindex == 8 || newindex == 16 || newindex == 23)
                return true;
        }
        else if (oldIndex == 30)
        {
            if (newindex == 30 || newindex == 31 || newindex == 23)
                return true;
        }
        else if (oldIndex == 7)
        {
            if (newindex == 7 || newindex == 6 || newindex == 14)
                return true;
        }
        else if (oldIndex == 22)
        {
            if (newindex == 22 || newindex == 21 || newindex == 14 || newindex == 37)
                return true;
        }
        else if (oldIndex == 37)
        {
            if (newindex == 37 || newindex == 36 || newindex == 29)
                return true;
        }
        else if ((oldIndex >= 8 && oldIndex <= 14) || ((oldIndex >= 23 && oldIndex <= 29)))
        {
            if (newindex == oldIndex || newindex == oldIndex + 8 || newindex == oldIndex + 7 ||
                newindex == oldIndex - 7 || newindex == oldIndex - 8)
                return true;

            if (oldIndex == 8 && newindex == 9)
                return true;
            else if (oldIndex == 14 && newindex == 13)
                return true;
            else if (oldIndex == 23 && newindex == 24)
                return true;
            else if (oldIndex == 29 && newindex == 28)
                return true;
            else if ((oldIndex != 8 && oldIndex != 14 && oldIndex != 23 && oldIndex != 29)
                && (oldIndex == newindex + 1 || oldIndex == newindex - 1))
                return true;
        }
        else if (oldIndex >= 16 && oldIndex <= 21)
        {
            if (newindex == oldIndex || newindex == oldIndex + 8 || newindex == oldIndex + 7 ||
                newindex == oldIndex - 7 || newindex == oldIndex - 8 ||
                newindex == oldIndex + 1 || newindex == oldIndex - 1)
                return true;
        }
        else if (oldIndex >= 1 || oldIndex <= 6)
        {
            if (newindex == oldIndex || newindex == oldIndex + 8 || newindex == oldIndex + 7 ||
                newindex == oldIndex + 1 || newindex == oldIndex - 1)
                return true;
        }
        else //31-36
        {
            if (newindex == oldIndex || newindex == oldIndex - 8 || newindex == oldIndex - 7 ||
                newindex == oldIndex + 1 || newindex == oldIndex - 1)
                return true;
        }
        return false;
    }
}
