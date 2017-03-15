using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour {

    public HexGrid hexgrid;
    private HexCell[] cells;
    private Color mouseOverColor = new Color(1, 0, 0, 0.4f);
    private Color originalColor;
    private bool dragging = false;
    private float distance;
    private int oldIndex = 0;

    private List<Vector3> cellPositions;
    private Renderer renderer;

    public Vector3 globalPosition;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }
    
    // Use this for initialization
    void Start () {
        cells = hexgrid.cells;
        cellPositions = new List<Vector3>();
        foreach (HexCell cell in cells)
        {
            cellPositions.Add(cell.transform.position);
        }
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
    }

    void OnMouseUp()
    {
        hexgrid.occupiedCells[oldIndex] = false;
        dragging = false;
       
        Vector3 currentPosition = transform.position;
        globalPosition = currentPosition;

        Vector3 closetCell = new Vector3(0,0,0);
        float dist = float.MaxValue;
        int index = 0;
        for (int i = 0; i < cellPositions.Count; i++)
        {
            Vector3 v = cellPositions[i];
        
            if (Vector3.Distance(v, currentPosition) < dist && hexgrid.occupiedCells[i] == false)
            {
                dist = Vector3.Distance(v, currentPosition);
                closetCell = v;
                index = i;
            }
        }
        transform.position = new Vector3(closetCell.x, 0f, closetCell.z);
        hexgrid.occupiedCells[index] = true;
        oldIndex = index;
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
}
