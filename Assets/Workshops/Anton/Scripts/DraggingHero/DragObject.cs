using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private GameObject selectedObject;
    private bool onRay = false; 
    private RaycastHit ray;
    Transform pelviosHit;
    RaycastHit hit;

    private void Start() 
    {
        pelviosHit = transform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selectedObject = eventData.pointerEnter;
        transform.GetComponent<Rigidbody>().isKinematic = true;
        onRay = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        FolowToMouse();
        ChangeColor();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetComponent<Rigidbody>().isKinematic = false;
        onRay = false;
        if(hit.transform)
        {
            selectedObject.transform.position = hit.transform.position;
        }
        
    }

    
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

    //преследовать кординаты мышки
    private void FolowToMouse()
    {
        if (selectedObject)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            Vector3 targetPos = new Vector3(worldPosition.x, 1, worldPosition.z);
            // selectedObject.transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 20f);
            selectedObject.transform.position = new Vector3(worldPosition.x, 1, worldPosition.z);
        }
    }

    //сменить цвет того что внизу
    private void ChangeColor()
    {
        if (onRay)
        {
            Vector3 down = transform.TransformDirection(Vector3.down);

            if (Physics.Raycast(transform.position, down, out hit))
            {
                hit.transform.GetComponent<Renderer>().material.color = Color.gray;

                if (pelviosHit.transform != hit.transform && pelviosHit.GetComponent<Renderer>())
                {
                    pelviosHit.GetComponent<Renderer>().material.color = new Color(0.1847633f, 0.2068142f, 0.2264151f, 1);
                }
                pelviosHit = hit.transform;
            }
        }
    }
}
