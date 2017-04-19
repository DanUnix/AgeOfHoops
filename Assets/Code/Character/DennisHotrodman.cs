using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  AI for NPC Dennis Hotrodman
 *  Current behaviour is to follow player (Kuroko) in the Z direction in fixed positions
 *  His behaviour is meant to be a tutorial for the player and thus very simplified
 */
  
public class DennisHotrodman : MonoBehaviour {

    public HexGrid hexgrid;

    private float distance;
    private int oldIndex;

    public RoundCounter gameRound;
    private List<Vector3> cellPositions;

    private int prevRound;
    private int currRound;

    public CharacterMovement2 kuroko;
    private Vector3 kurokosOldPosition;
    private Vector3 kurokosNewPosition;

    private Vector3 originalPosition;

    void Awake()
    {
        oldIndex = 0;
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
        kurokosOldPosition = kuroko.globalPosition;
        kurokosNewPosition = kurokosOldPosition;

        originalPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        currRound = gameRound.getRoundCounter();
        if (currRound != prevRound)
        {
            kurokosNewPosition = kuroko.globalPosition;

            MoveAI();

            kurokosOldPosition = kurokosNewPosition;
        }
        prevRound = currRound;
    }

    void PinPosition()
    {
        hexgrid.occupiedCells[oldIndex] = 0;

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

    void MoveAI()
    {
        float z;
        z = kurokosNewPosition.z - kurokosOldPosition.z;
        int newIndex;

        //3 for initial offset of 2.6 in position difference
        if (z > 3 && (oldIndex == 23 || oldIndex == 8))
        {
            newIndex = oldIndex + hexgrid.width - 1;

        }
        else if (z > 3 && (oldIndex == 0 || oldIndex == 15))
        {
            newIndex = oldIndex + hexgrid.width;
        }
        else if (z < -3 && (oldIndex == 23 || oldIndex == 8))
        {
            newIndex = oldIndex - hexgrid.width;
        }
        else if (z < -3 && (oldIndex == 15 || oldIndex == 30))
        {
            newIndex = oldIndex - hexgrid.width + 1;    
        }
        else
        {
            newIndex = oldIndex;    
        }

        if (newIndex < 0 || newIndex >= cellPositions.Count)
        {
            newIndex = oldIndex;
        }

        transform.position = new Vector3(cellPositions[newIndex].x, 0f, cellPositions[newIndex].z);
        hexgrid.occupiedCells[oldIndex] = 0;
        hexgrid.occupiedCells[newIndex] = 2;
        oldIndex = newIndex;
    }

    public void resetPosition()
    {
        transform.position = originalPosition;
    }
}
