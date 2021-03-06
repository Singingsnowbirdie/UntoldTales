using UnityEngine;

//узел в котором хранится позиция на поле, 
//так же тут хранится стоимость хода
//и хранится ссылка на предыдущую ноду
public class Noddde 
{
    public Vector3 myPosition;
    public Vector3 targetPosition;
    public Noddde pelviosNode;

    //f = g + h
    public int f;

    //растояник от старта к себе
    public int g;

    //растояние по X от себя к цели + растояние от себя к цели по Y
    public int h;

    public Noddde(int g, Vector3 myPosition, Vector3 targetPosition, Noddde pelviosNode)
    {
        this.myPosition = myPosition;
        this.targetPosition = targetPosition;
        this.pelviosNode = pelviosNode;
        this.g = g;
        
        h = (int) Mathf.Abs(targetPosition.x - myPosition.x) 
          + (int) Mathf.Abs(targetPosition.z - myPosition.z);
        
        f = g + h;
    }

}
