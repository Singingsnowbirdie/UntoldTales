using UnityEngine;

public class Point : MonoBehaviour
{
    //тип точки
    [SerializeField]
    PointType type;
    public PointType Type { get => type;}
}
