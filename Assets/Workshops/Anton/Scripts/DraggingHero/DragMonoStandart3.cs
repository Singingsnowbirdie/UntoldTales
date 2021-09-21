using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс отвечает за перетаскивание мышкой объекты
public class DragMonoStandart3 : MonoBehaviour
{

    public GameObject selectedObject;

    void FixedUpdate()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();
                if(hit.collider !=null)
                {
                    selectedObject = hit.collider.gameObject;
                }

                
            }
            
        }

        if (selectedObject)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, 0.25f, worldPosition.z);
        }

        
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
