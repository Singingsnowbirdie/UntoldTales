using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class Ai : MonoBehaviour
{
    private Pathfinding pathfinding;
    // private MyTest pathfinding;

    public float speed = 0.05f;
    public float offset;

    private Vector3 target2;
    private bool on = true;
    private Animator anim;

    private void Start() 
    {
        anim = transform.GetComponent<Animator>();
        pathfinding = transform.GetComponent<Pathfinding>();    
        // pathfinding = transform.GetComponent<MyTest>();    
    }

    private void Update() 
    {
        GoToTarget();
    }   

    public void Enabled()
    {
        transform.GetComponent<Pathfinding>().enabled = true;
    }
    
    private void GoToTarget()
    {
        if(pathfinding.pathToTarget.Count > 0)
        {
            Vector3 target = pathfinding.pathToTarget[pathfinding.pathToTarget.Count - 1]; 
            
            if(on && pathfinding.pathToTarget.Count > 1)
            {
                target2 = target;
                on = false;
            }

            if(transform.position == new Vector3(target2.x + offset, 0, target2.z + offset))
            {
                on = true;
            }

            if (pathfinding.pathToTarget.Count > 1 && Vector3.Distance(transform.position, new Vector3(target2.x + offset, 0, target2.z + offset))> 0.2f)
            {
                RotationToTarget(new Vector3(target2.x + offset, 0, target2.z + offset), 20);
                anim.SetBool("walkNoWeapon", true);
            }
            else if (pathfinding.pathToTarget.Count == 1)
            {
                RotationToTarget(new Vector3(target.x + offset, 0, target.z + offset), 20);
                anim.SetBool("walkNoWeapon", false);
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target2.x + offset, 0, target2.z + offset), Time.deltaTime * speed);
        }
        
    }

    //метод поворачивает обьект к цели по Y
    public void RotationToTarget(Vector3 target, float speed)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion locrot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, locrot, Time.deltaTime * speed);

    }
}
