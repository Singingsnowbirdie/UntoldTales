using UnityEngine;

public class Point : MonoBehaviour
{
    //тип точки
    [SerializeField]
    PointType type;
    public PointType Type { get => type;}

    //моб или герой, стоящий на этой точке
    public GameObject ChildrenCharacter { get; set; }
}
