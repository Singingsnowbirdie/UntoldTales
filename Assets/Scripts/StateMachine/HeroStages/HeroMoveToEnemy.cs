using UnityEngine;

public class HeroMoveToEnemy : IStage
{

    private Character character;
    public Pathfinding pathfinding;

    private float speed = 4.14f;
    private float offset = 0.5f;

    private Vector3 target2;
    private bool on = true;

    private Animator anim;

    public string StageName { get; set; }

    public HeroMoveToEnemy(Character character)
    {
        this.character = character;
        anim = this.character.transform.GetComponent<Animator>();
        pathfinding = this.character.transform.GetComponent<Pathfinding>();
    }

    public void Enter()
    {
        MoveToEnemy();
    }

    public void Exit()
    {
        // Debug.Log("HeroMoveToEnemy выход");
    }

    private void SetNextState()
    {        
        if (character.CurrentTarget) character.heroStateMachine.SetStage(character.heroStateMachine.Stages[typeof(HeroAttackEnemy)]);
    }
    
    /// <summary>
    /// метод двигает персонажа к цели !!!Это кастыльный метод. Нужно переписать!!!
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
    ///метод поворачивает обьект к цели по Y
    /// </summary>
    public void RotateToTarget(Vector3 target, float speed)
    {
        Vector3 direction = (target - character.transform.position).normalized;
        Quaternion locrot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation, locrot, Time.deltaTime * speed);
    }
}
