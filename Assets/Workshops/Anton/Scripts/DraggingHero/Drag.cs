using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        // transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, 3));

       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clic");
    }
}
