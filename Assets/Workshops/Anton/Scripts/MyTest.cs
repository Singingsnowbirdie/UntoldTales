using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    public GameObject target;
    public Board board;
    public LayerMask solidLayer;

    //список точек к цели найденый путь
    public List<Vector3> pathToTarget;

    //список провереных узлов
    private List<Noddde> checkedNodes;

    //список узлов которые ждут проверку
    public List<Noddde> waitingNodes;
    

    private void Awake() 
    {
        board = FindObjectOfType<Board>();
    }

    public void GetPathToTarget()
    {
        pathToTarget = GetPath(target.transform.position);
    }

    private void Pathfindind()
    {
        board.CreateGrid();
        pathToTarget = new List<Vector3>();
        checkedNodes = new List<Noddde>();
        waitingNodes = new List<Noddde>();

    }

    //метод проверяет не вышел ли кто за границы поля
    private bool Сhecking_Borders(Vector3 bodyPos, Vector2 boardPos)
    {
        if(bodyPos.x - board.transform.position.x > board.widthAndHeight.x
        || bodyPos.z - board.transform.position.z > board.widthAndHeight.y
        || bodyPos.x - board.transform.localPosition.x < board.transform.localPosition.x
        || bodyPos.z - board.transform.localPosition.z < board.transform.localPosition.z) 
        {
            Debug.Log("выход за рамки");
            return false;
        }
        return true;
    }

    private Vector3 Get_Position(GameObject person)
    {
        return new Vector3(Mathf.Round(person.transform.position.x - 0.5f) + board.transform.position.x, 0
        , Mathf.Round(person.transform.position.z - 0.5f) + board.transform.position.z);
    }

    private List<Vector3> GetPath(Vector3 myTarget)
    {
        pathToTarget = new List<Vector3>();
        checkedNodes = new List<Noddde>();
        waitingNodes = new List<Noddde>();        
        
        if(!Сhecking_Borders(transform.position, board.transform.position)) return null;

        // Vector3 startPosition = new Vector3(Mathf.Round(transform.position.x - 0.5f) + board.transform.position.x, 0, Mathf.Round(transform.position.z - 0.5f) + board.transform.position.z);
        // // //точка, конечная позиция 
        // Vector3 targetPosition = new Vector3(Mathf.Round(target.transform.position.x - 0.5f) + board.transform.position.x, 0, Mathf.Round(target.transform.position.z - 0.5f) + board.transform.position.z);
        Vector3 startPosition = Get_Position(transform.gameObject);
        Vector3 targetPosition = Get_Position(target);
        // Debug.Log(Mathf.Round(transform.position.x - 0.5f) + board.transform.position.x + " " + board.transform.localPosition.x);

        if (startPosition == targetPosition) return pathToTarget;
        
        //определяем самый первый узел
        Noddde startNode = new Noddde(0, startPosition, targetPosition, null);

        //и сразу устанавливаем его в список "проверенные" 
        checkedNodes.Add(startNode);

        //затем находим соседние клетки и вносим их в список "ждущие проверку"
        waitingNodes.AddRange(GetNeighbourNodes(startNode));
        
        while(waitingNodes.Count > 0)
        {
            //выбираем из списка ожидающий проверки узел с минимальным значением f
            Noddde nodeToCheck = waitingNodes.Where(x => x.f == waitingNodes.Min(y => y.f)).FirstOrDefault();

            //если позиция узла с минимальным f равна позиции таргета 
            if (nodeToCheck.myPosition == targetPosition)
            {
                return CalculatePathFromNode(nodeToCheck);
            }

            //проверка можно ли ходить по узлу или это стена
            var walkable = Physics.OverlapSphere(new Vector3(nodeToCheck.myPosition.x + 0.5f, 0, nodeToCheck.myPosition.z + 0.5f), 0.4f, solidLayer);

            if (walkable.Length > 0)
            {
                waitingNodes.Remove(nodeToCheck);
                checkedNodes.Add(nodeToCheck);
            }
            else if (walkable.Length == 0)
            {
                waitingNodes.Remove(nodeToCheck);

                //проверка нет ли в списке уже провереных узлов, вот этого nodeToCheck узла  
                if (!checkedNodes.Where(x => x.myPosition == nodeToCheck.myPosition).Any())
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
        while (currendNode.pelviosNode != null)
        {
            //устанавливаем в список узелов тчку по которой пойдет персонаж
            path.Add(new Vector3(currendNode.myPosition.x, 0, currendNode.myPosition.z));

            //убераем узел
            currendNode = currendNode.pelviosNode;
        }       
        return path;
    }
    
    private List<Noddde> GetNeighbourNodes(Noddde node)
    {
        List<Noddde> neighbours = new List<Noddde>();
        //влево
        if((node.myPosition.x - (board.transform.position.x)) > 0)
        {
            //влево
            neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z), node.targetPosition, node));
            
            if ((node.myPosition.z - (board.transform.position.z)) > 0)
            {
                //лево низ
                neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z - 1), node.targetPosition, node));
            }
        }
        //право
        if ((node.myPosition.x - (board.transform.position.x)) < board.widthAndHeight.x - 1)
        {
            //право
            neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z), node.targetPosition, node));

            if ((node.myPosition.z - (board.transform.position.z)) > 0)
            {
                //право низ
                neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z - 1), node.targetPosition, node));
            }
        }
        
        if ((node.myPosition.z - (board.transform.position.z)) > 0)
        {
            //центр вниз    
            neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x, 0, node.myPosition.z - 1), node.targetPosition, node));
        }
        
        if ((node.myPosition.z - (board.transform.position.x)) < board.widthAndHeight.y - 1)
        {
            //центр вверх
            neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x, 0, node.myPosition.z + 1), node.targetPosition, node));
        
            //право вверх
            if ((node.myPosition.x - (board.transform.position.x)) < board.widthAndHeight.x - 1)
            {
                neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z + 1), node.targetPosition, node));
            }

            if ((node.myPosition.x - (board.transform.position.x)) > 0)
            {
                //лево вверх
                neighbours.Add(new Noddde(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z + 1), node.targetPosition, node));
            }
        }        
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

        if (pathToTarget != null)
        {
            foreach (var item in pathToTarget)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(new Vector3(item.x + 0.5f, 0, item.z + 0.5f ), 0.1f);

            }
        }
    }
}

