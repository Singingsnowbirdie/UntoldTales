using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс игровой доски 
//создает доску
public class Board : MonoBehaviour
{
    //префаб маршрутной точки
    public GameObject waypointPrefab;
    //кол-во ячеек поля
    public Vector2Int widthAndHeight;
    //размер самих ячеек
    public float cellSize;

    //массив ячеек
    public int[,] gridArray;
    //массив маршрутных точек    
    public GameObject[,] gameObjectsCell;

    private void Awake()
    {
        gridArray = new int[widthAndHeight.x, widthAndHeight.y];
        gameObjectsCell = new GameObject[widthAndHeight.x, widthAndHeight.y];
        CreateGrid();
    }

    //метод создает сетку и маршрутные точки
    public void CreateGrid()
    {
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
              //  gameObjectsCell[x, z] = Instantiate(waypointPrefab, GetWorldPos(x + transform.position.x, z + transform.position.z)
                // + new Vector3(cellSize, 0, cellSize) * .5f, Quaternion.identity);

                DrawGrid(x,z);
            }
        }
    }

    //метод определяет размер сетки
    private Vector3 GetWorldPos(float x, float z)
    {
        return new Vector3(x, 0, z) * cellSize;
    }

    //метод выделяет маршрутную точку
    private void TestSetTarget(int x, int z)
    {
        //условие не позволяет выйти за приделы поля
        if (x >= 0 && z >= 0 && x < widthAndHeight.x && z < widthAndHeight.y)
        {
            gameObjectsCell[x, z].GetComponent<Renderer>().material.color = Color.red;
        }
    }
   
    //метод рисует линии сетки
    private void DrawGrid(int x, int z)
    {
        Debug.DrawLine(GetWorldPos(x + transform.position.x, z + transform.position.z),
         GetWorldPos(x + transform.position.x, z + transform.position.z + 1), Color.white, 200f);

        Debug.DrawLine(GetWorldPos(x + transform.position.x, z + transform.position.z),
         GetWorldPos(x + transform.position.x + 1, z + transform.position.z), Color.white, 200f);
    }    
}
