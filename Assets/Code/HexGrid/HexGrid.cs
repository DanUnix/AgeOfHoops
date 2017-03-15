using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public int width = 8;
    public int height = 5;

    public HexCell cellPrefab;

    public Text cellLabelPrefab;

    public bool debug;

    public bool[] occupiedCells;

    HexMesh hexMesh;

    Canvas gridCanvas; 

    public HexCell[] cells;

    
    void Awake() {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();
        cells = new HexCell[height * width];
        occupiedCells = new bool[height * width];
     
        for (int z = 0, i = 0; z < height; z++) {
            for (int x = 0; x < width; x++) {
                occupiedCells[z * width + x] = false;
                if (!(z % 2 == 1 && x == (width - 1))) {
                    CreateCell(x, z, i++);
                } 
            }
        }
    }

    void CreateCell(int x, int z, int i) {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);


        if (debug)
        {
            Text label = Instantiate<Text>(cellLabelPrefab);
            label.rectTransform.SetParent(gridCanvas.transform, false);
            label.rectTransform.anchoredPosition =
                new Vector2(position.x, position.z);
            label.text = cell.coordinates.ToStringOnSeparateLines();
        }




    }
    // Use this for initialization
    void Start () {
        hexMesh.Triangulate(cells);
    }

    // Update is called once per frame
    void Update()
    {
        //if (input.getmousebutton(0))
        //{
        //    handleinput();
        //}
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitRay;
        if (Physics.Raycast(inputRay, out hitRay))
        {
            TouchCell(hitRay.point);
        }
    }

   

    void TouchCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        Debug.Log("touched at " + coordinates.ToString());

    }

    
}
