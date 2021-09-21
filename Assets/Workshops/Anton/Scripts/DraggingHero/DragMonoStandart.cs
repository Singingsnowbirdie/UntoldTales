using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMonoStandart : MonoBehaviour
{
    public Vector3 mousePoint;
    private Vector3 offset;
    private float mZCoord;
    public Camera mainCam;

    private void OnMouseDown() 
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPosition();
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset; 
        // transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {

         mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
