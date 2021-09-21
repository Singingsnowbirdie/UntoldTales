using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLaseObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform cube;
    private Vector3 mousePos;

    public Vector3 smoothMousePosition;
    public int height;
    public int width;

    private Node [,] nodes;
    private Plane plane;

    void Start()
    {
        CreateGrid();
        plane = new Plane(Vector3.up, transform.position);
    }

    private void CreateGrid()
    {
        nodes = new Node[width, height];
        var name = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i, 0.01f, j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell" + name;
                nodes[i, j] = new Node(true, worldPosition, obj);
                name++;
            }
        }
    }
    float enter = 0.0f;
    void GetMousePositionOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out enter))
        {
            mousePos = ray.GetPoint(enter);
            smoothMousePosition = mousePos;
            mousePos.y = 0;
            mousePos = Vector3Int.RoundToInt(mousePos);
        }
       
    }

    void Update()
    {
        // GetMousePositionOnGrid();
    }
    public class Node
    {
        public bool isPlaceable;
        public Vector3 cellPosition;
        public Transform obj;

        public Node(bool isPlaceable, Vector3 cellPosition, Transform obj)
        {
            this.isPlaceable = isPlaceable;
            this.cellPosition = cellPosition;
            this.obj = obj;
        }
    }
}


