using UnityEngine;

//Состояние персонажа: сближение с целью

public class EnemyApproachingStage : IStage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public EnemyApproachingStage(Character character)
    {
        this.character = character;
        anim = this.character.transform.GetComponent<Animator>();
        pathfinding = this.character.transform.GetComponent<Pathfinding>();
    }

    /// <summary>
    /// Персонаж
    /// </summary>
    private Character character;

    /// <summary>
    /// ПОиск пути
    /// </summary>
    public Pathfinding pathfinding;

    /// <summary>
    /// Скорость
    /// </summary>
    private float speed = 4.14f;

    /// <summary>
    /// Поправка
    /// </summary>
    private float offset = 0.5f;

    /// <summary>
    /// Цель
    /// </summary>
    private Vector3 target2;

    /// <summary>
    /// !Переименовать осмысленно
    /// </summary>
    private bool on = true;

    /// <summary>
    /// Аниматор
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Вход в состояние
    /// </summary>
    public void EnterStage()
    {
        MoveToEnemy();
    }

    /// <summary>
    /// Выход из состояния
    /// </summary>
    public void ExitStage()
    {
    }

    /// <summary>
    /// Устанавливает следующее состояние
    /// </summary>
    private void SetNextState()
    {        
        if (character.CurrentTarget) character.stateMachine.SetStage(character.stateMachine.Stages[typeof(AttackStage)]);
    }
    
    /// <summary>
    /// Двигает персонажа к цели !!!Это кастыльный метод. Нужно переписать!!!
    /// </summary>
    private void MoveToEnemy()
    {
        
        pathfinding.GetPathToTarget();

        if (pathfinding.pathToTarget.Count > 0)
        {
            Vector3 target = pathfinding.pathToTarget[pathfinding.pathToTarget.Count - 1];

            if (on && pathfinding.pathToTarget.Count > 1)
            {
                target2 = target;
                on = false;
            }

            if (character.transform.position == new Vector3(target2.x + offset, 0, target2.z + offset))
            {
                on = true;
            }

            if (pathfinding.pathToTarget.Count > 1 &&
                Vector3.Distance(character.transform.position, new Vector3(target2.x + offset, 0, target2.z + offset)) > 0.2f)
            {
                Debug.Log("иду к цели");
                RotateToTarget(new Vector3(target2.x + offset, 0, target2.z + offset), 20);
                anim.SetBool("walkNoWeapon", true);
            }
            else if (pathfinding.pathToTarget.Count == 1)
            {
                RotateToTarget(new Vector3(target.x + offset, 0, target.z + offset), 20);
                anim.SetBool("walkNoWeapon", false);
                SetNextState();
            }

            Vector3 actualTargetPositint = new Vector3(target2.x + offset, 0, target2.z + offset);
            character.transform.position = 
            Vector3.MoveTowards(character.transform.position, actualTargetPositint, Time.deltaTime * speed);
        }
    }
    

    /// <summary>
    /// Поворачивает обьект к цели по Y
    /// </summary>
    public void RotateToTarget(Vector3 target, float speed)
    {
        Vector3 direction = (target - character.transform.position).normalized;
        Quaternion locrot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation, locrot, Time.deltaTime * speed);
    }
}
