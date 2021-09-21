using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//алгоритм поиска пути "А*"
//использует иговую доску для поиска пути по ней
public class Pathfinding : MonoBehaviour
{
    Board board;
    //список точек к цели найденый путь
    public List<Vector3> pathToTarget;

    //список провереных узлов
    public List<Noddde> checkedNodes;  
    
    //список узлов которые ждут проверку
    public List<Noddde> waitingNodes;   

    //цель    
    public GameObject target;
    public float offset;

    public LayerMask solidLayer; 

    private void Start() 
    {
        board = FindObjectOfType<Board>();
    }

    void Update()
    {
        pathToTarget = GetPath(target.transform.position);
    }

    public List<Vector3> GetPath(Vector3 myTarget)
    {
        pathToTarget = new List<Vector3>();
        checkedNodes = new List<Noddde>();
        waitingNodes = new List<Noddde>();

        //точка, стартовая позиция откуда начинаем искать путь 
        Vector3 startPosition = new Vector3(Mathf.Round(transform.position.x - offset),0, Mathf.Round(transform.position.z - offset));
        //точка, конечная позиция 
        Vector3 targetPosition = new Vector3(Mathf.Round(target.transform.position.x - offset),0, Mathf.Round(target.transform.position.z - offset));
        
        //проверка пришли мы к цели или нет
        if(startPosition == targetPosition)return pathToTarget;
        
        //определяем самый первый узел
        Noddde startNode = new Noddde(0, startPosition, targetPosition, null);

        //и сразу устанавливаем его в список "проверенные" 
        checkedNodes.Add(startNode);

        //затем находим соседние клетки и вносим их в список "ждущие проверку"
        waitingNodes.AddRange(GetNeighbourNodes(startNode));

        //цикл работает пока существует хотя бы один узел ожидающий проверки 
        while(waitingNodes.Count > 0)
        {
            //выбираем из списка ожидающий проверки узел с минимальным значением f
            Noddde nodeToCheck = waitingNodes.Where(x => x.f == waitingNodes.Min(y => y.f)).FirstOrDefault();

            //если позиция узла с минимальным f равна позиции таргета 
            if(nodeToCheck.myPosition == targetPosition)
            {
                return CalculatePathFromNode(nodeToCheck);
            }

            //проверка можно ли ходить по узлу или это стена
            var walkable = Physics.OverlapSphere(new Vector3(nodeToCheck.myPosition.x + offset, 0,nodeToCheck.myPosition.z + offset), 0.4f, solidLayer);

            if(walkable.Length > 0)
            {
                waitingNodes.Remove(nodeToCheck);
                checkedNodes.Add(nodeToCheck);
            }
            else if(walkable.Length == 0)
            {
               waitingNodes.Remove(nodeToCheck);

                //проверка нет ли в списке уже провереных узлов, вот этого nodeToCheck узла  
                if(!checkedNodes.Where(x => x.myPosition == nodeToCheck.myPosition).Any())
                {
                    checkedNodes.Add(nodeToCheck);
                    waitingNodes.AddRange(GetNeighbourNodes(nodeToCheck));
                }                
            }
        }

        return pathToTarget;
    }

    //метод формирует список точек по которым пойдет персонаж
    public List<Vector3> CalculatePathFromNode(Noddde node)
    {
        var path = new List<Vector3>();
        Noddde currendNode = node;
        
        //цикл работает пока узел имеет вложеный узел 
        while (currendNode.pelviosNode !=null)
        {
            //устанавливаем в список узелов тчку по которой пойдет персонаж
            path.Add(new Vector3(currendNode.myPosition.x, 0, currendNode.myPosition.z));

            //убераем узел
            currendNode = currendNode.pelviosNode;
        }
        return path;
    }

    //метод определяет соседние клетки 
    private List<Noddde> GetNeighbourNodes(Noddde node)
    {
        List<Noddde> neighbours = new List<Noddde>();

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z), node.targetPosition, node));

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z), node.targetPosition, node));

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x, 0, node.myPosition.z - 1),node.targetPosition, node));

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x, 0, node.myPosition.z + 1),node.targetPosition, node));

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z + 1),node.targetPosition, node));

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z - 1),node.targetPosition, node));

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z + 1),node.targetPosition, node));

        neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z - 1),node.targetPosition, node));

        return neighbours;
    }

    private void OnDrawGizmos() 
    {
        // if (checkedNodes != null)

        // foreach (var item in checkedNodes)
        // {
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawSphere(new Vector3(item.myPosition.x + offset,0, item.myPosition.z + offset), 0.1f);
        // }

        // if (waitingNodes != null)

        //     foreach (var item in waitingNodes)
        //     {
        //         Gizmos.color = Color.blue;
        //         Gizmos.DrawSphere(new Vector3(item.myPosition.x + offset, 0, item.myPosition.z + offset), 0.1f);
        //     }

        if(pathToTarget != null)
        foreach (var item in pathToTarget)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(new Vector3(item.x + offset, 0, item.z + offset), 0.1f);
        }    
    }
}
