using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    [System.Serializable]
    public class Person
    {
        public Transform Myransform;
        public float xBoard;
        public float zBoard;
    }
    public Transform prefab;

    public Board board;
    //список точек к цели найденый путь
    public List<Vector3> pathToTarget;

    //список провереных узлов
    public List<Node> checkedNodes;

    public LayerMask solidLayer;

    //список узлов которые ждут проверку
    [SerializeField]
    public List<Node> waitingNodes;

    [SerializeField]
    public List<Person> currentNodes;
    

    private void Awake() 
    {
        board = FindObjectOfType<Board>();
        pathToTarget = GetPath();
    }

    void Update()
    {
        pathToTarget = GetPath();
    }

    private void Pathfindind()
    {
        board.CreateGrid();
        pathToTarget = new List<Vector3>();
        checkedNodes = new List<Node>();
        waitingNodes = new List<Node>();

    }

    //метод проверяет не вышел ли кто за границы поля
    /*private bool Сhecking_Borders(Vector2 bodyPos, Vector2 boardPos)
    {
        if(bodyPos.x - (boardPos.x + 0.5f) > boardPos.x + 0.5f
        ||) 
        return true;
    }*/


    private List<Vector3> GetPath()
    {
        pathToTarget = new List<Vector3>();
        checkedNodes = new List<Node>();
        waitingNodes = new List<Node>();

        //точка, стартовая позиция откуда начинаем искать путь 
        if(currentNodes[0].Myransform.position.x - (board.transform.position.x + 0.5f) > board.widthAndHeight.x
        || currentNodes[0].Myransform.position.z - (board.transform.position.z + 0.5f) > board.widthAndHeight.y
        || currentNodes[0].Myransform.position.x - (board.transform.position.x + 0.5f) < 0
        || currentNodes[0].Myransform.position.x - (board.transform.position.z + 0.5f) < 0)
        {
            Debug.Log("выход за рамки");
            return null;
        }

        if (currentNodes[1].Myransform.position.x - (board.transform.position.x + 0.5f) > board.widthAndHeight.x
        || currentNodes[1].Myransform.position.z - (board.transform.position.z + 0.5f) > board.widthAndHeight.y
        || currentNodes[1].Myransform.position.x - (board.transform.position.x + 0.5f) < 0
        || currentNodes[1].Myransform.position.x - (board.transform.position.z + 0.5f) < 0)
        {
            Debug.Log("выход за рамки");
            return null;
        }

        Vector3 startPosition = new Vector3(Mathf.Round(currentNodes[0].Myransform.position.x - 0.5f) , 0, Mathf.Round(currentNodes[0].Myransform.position.z - 0.5f));

        // //точка, конечная позиция 
        Vector3 targetPosition = new Vector3(Mathf.Round(currentNodes[1].Myransform.position.x - 0.5f) , 0, Mathf.Round(currentNodes[1].Myransform.position.z - 0.5f));

        if (startPosition == targetPosition) return pathToTarget;

        //определяем самый первый узел
        Node startNode = new Node(0, startPosition, targetPosition, null);

        //и сразу устанавливаем его в список "проверенные" 
        checkedNodes.Add(startNode);

        //затем находим соседние клетки и вносим их в список "ждущие проверку"
        waitingNodes.AddRange(GetNeighbourNodes(startNode));
        
        while(waitingNodes.Count > 0)
        {
            //выбираем из списка ожидающий проверки узел с минимальным значением f
            Node nodeToCheck = waitingNodes.Where(x => x.f == waitingNodes.Min(y => y.f)).FirstOrDefault();

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
    public List<Vector3> CalculatePathFromNode(Node node)
    {
        var path = new List<Vector3>();
        Node currendNode = node;

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
    
    private List<Node> GetNeighbourNodes(Node node)
    {
        List<Node> neighbours = new List<Node>();

        //влево
        if((node.myPosition.x - (board.transform.position.x)) > 0)
        {
            //влево
            neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z), node.targetPosition, node));

            if ((node.myPosition.z - (board.transform.position.z)) > 0)
            {
                //лево низ
                neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z - 1), node.targetPosition, node));
            }
        }
        //право
        if ((node.myPosition.x - (board.transform.position.x)) < board.widthAndHeight.x - 1)
        {
            //право
            neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z), node.targetPosition, node));

            if ((node.myPosition.z - (board.transform.position.z)) > 0)
            {
                //право низ
                neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z - 1), node.targetPosition, node));
            }
        }
        
        if ((node.myPosition.z - (board.transform.position.z)) > 0)
        {
            //центр вниз    
            neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x, 0, node.myPosition.z - 1), node.targetPosition, node));
        }
        
        if ((node.myPosition.z - (board.transform.position.x)) < board.widthAndHeight.y - 1)
        {
            //центр вверх
            neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x, 0, node.myPosition.z + 1), node.targetPosition, node));
        
            //право вверх
            if ((node.myPosition.x - (board.transform.position.x)) < board.widthAndHeight.x - 1)
            {
                neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x + 1, 0, node.myPosition.z + 1), node.targetPosition, node));
            }

            if ((node.myPosition.x - (board.transform.position.x)) > 0)
            {
                //лево вверх
                neighbours.Add(new Node(node.g + 1, new Vector3(node.myPosition.x - 1, 0, node.myPosition.z + 1), node.targetPosition, node));
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
            foreach (var item in pathToTarget)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(new Vector3(item.x + 0.5f , 0, item.z + 0.5f), 0.1f);
                
            }
    }

}

