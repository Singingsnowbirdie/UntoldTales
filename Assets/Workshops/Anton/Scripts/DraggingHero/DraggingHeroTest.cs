using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggingHeroTest : EventTrigger
{
    private bool dragging;
    void Update()
    {
        if(dragging)
        {
            transform.position = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.z);
        }   
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
