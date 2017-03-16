using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DennisHotrodman : MonoBehaviour {

    public HexGrid hexgrid;

    private bool dragging = false;
    private float distance;
    private int oldIndex = 0;

    public RoundCounter gameRound;
    private List<Vector3> cellPositions;

    private int prevRound;
    private int currRound;


    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        prevRound = gameRound.getRoundCounter();
        currRound = prevRound;

        HexCell[] cells = hexgrid.cells;
        cellPositions = new List<Vector3>();
        foreach (HexCell c in cells)
        {
            if (c != null) // skip the null cells (to make symmetrical board)
                cellPositions.Add(c.transform.position);
        }
        PinPosition();
    }


    // Update is called once per frame
    void Update()
    {
    }

    void PinPosition()
    {
        hexgrid.occupiedCells[oldIndex] = 0;
        dragging = false;

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
        hexgrid.occupiedCells[index] = 2;
        oldIndex = index;
    }
}
