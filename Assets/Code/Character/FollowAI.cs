using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour {

    public HexGrid hexgrid;
    public GameObject target;
    private HexCell[] cells;
    private List<Vector3> cellPositions;

    private int currRound;
    private int oldIndex = 0;
    public Vector3 globalPosition;

    public RoundCounter RC;


    // Use this for initialization
    void Start () {
        cells = hexgrid.cells;
        cellPositions = new List<Vector3>();
        foreach (HexCell cell in cells)
        {
            if (cell != null) // skip the null cells (to make symmetrical board)
                cellPositions.Add(cell.transform.position);
        }

        currRound = RC.roundCounter;
    }
	
	// Update is called once per frame
	void Update () {
        
		if(currRound != RC.roundCounter)
        {
            MoveChar();
            currRound = RC.roundCounter;
        }
	}

    void MoveChar()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 100f);

        hexgrid.occupiedCells[oldIndex] = 0;

        Vector3 currentPosition = transform.position;
        globalPosition = currentPosition;

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
    }
}
