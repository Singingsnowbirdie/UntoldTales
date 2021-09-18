using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ее : MonoBehaviour
{
    float speed = 0.01f;
    int a = 200;
    void Update()
    {
        a--;
        if(a <= 0)
        {
            speed = -speed;
            a = 200;
        }
        transform.Translate(0,0,speed);        
    }
}
