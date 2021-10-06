using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMoveToEnemy : IStage
{

    public Hero Hero;
    private Pathfinding pathfinding;

    private float speed = 4.14f;
    private float offset = 0.5f;

    private Vector3 target2;
    private bool on = true;
    private Animator anim;

    public void Enter()
    {
        
        anim = Hero.transform.GetComponent<Animator>();
        pathfinding = Hero.transform.GetComponent<Pathfinding>();
        MoveToEnemy();
    }

    public void Exit()
    {
        Debug.Log("выход");
    }

    private void SetNextState()
    {
        
        if (Hero.CurrentTarget) Hero.heroStateMachine.SetStage(Hero.heroStateMachine.Stages[typeof(HeroAttackEnemy)]);
    }

    private void Start()
    {
        anim = Hero.transform.GetComponent<Animator>();
        pathfinding = Hero.transform.GetComponent<Pathfinding>();
        // pathfinding = transform.GetComponent<MyTest>();    
    }

    /// <summary>
    /// метод двигает персонажа к цели !!!Это кастыльный метод. Нужно переписатьпр!!!
    /// </summary>
    private void MoveToEnemy()
    {
        if (pathfinding.pathToTarget.Count > 0)
        {
            Vector3 target = pathfinding.pathToTarget[pathfinding.pathToTarget.Count - 1];

            if (on && pathfinding.pathToTarget.Count > 1)
            {
                target2 = target;
                on = false;
            }

            if (Hero.transform.position == new Vector3(target2.x + offset, 0, target2.z + offset))
            {
                on = true;
            }

            if (pathfinding.pathToTarget.Count > 1 && Vector3.Distance(Hero.transform.position, new Vector3(target2.x + offset, 0, target2.z + offset)) > 0.2f)
            {
                RotationToTarget(new Vector3(target2.x + offset, 0, target2.z + offset), 20);
                anim.SetBool("walkNoWeapon", true);
            }
            else if (pathfinding.pathToTarget.Count == 1)
            {
                RotationToTarget(new Vector3(target.x + offset, 0, target.z + offset), 20);
                anim.SetBool("walkNoWeapon", false);
            }

            Hero.transform.position = Vector3.MoveTowards(Hero.transform.position, new Vector3(target2.x + offset, 0, target2.z + offset), Time.deltaTime * speed);
        }

    }

    
    public void Enabled()
    {
        Hero.transform.GetComponent<Pathfinding>().enabled = true;
    }

    /// <summary>
    ///метод поворачивает обьект к цели по Y
    /// </summary>
    public void RotationToTarget(Vector3 target, float speed)
    {
        Vector3 direction = (target - Hero.transform.position).normalized;
        Quaternion locrot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Hero.transform.rotation = Quaternion.Slerp(Hero.transform.rotation, locrot, Time.deltaTime * speed);
    }
}
