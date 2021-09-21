using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMOnoStanart2 : MonoBehaviour
{
    private void OnMouseDrag() 
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
