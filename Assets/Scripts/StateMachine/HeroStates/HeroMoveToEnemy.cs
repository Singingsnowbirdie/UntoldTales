using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMoveToEnemy : IStage
{

    private Hero Hero;
    public Pathfinding pathfinding;

    private float speed = 4.14f;
    private float offset = 0.5f;

    private Vector3 target2;
    private bool on = true;
    private Animator anim;

    public string StageName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public HeroMoveToEnemy(Hero Hero)
    {
        this.Hero = Hero;
        anim = Hero.transform.GetComponent<Animator>();
        pathfinding = Hero.transform.GetComponent<Pathfinding>();
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
        if (Hero.CurrentTarget) Hero.heroStateMachine.SetStage(Hero.heroStateMachine.Stages[typeof(HeroAttackEnemy)]);
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

            if (Hero.transform.position == new Vector3(target2.x + offset, 0, target2.z + offset))
            {
                on = true;
            }

            if (pathfinding.pathToTarget.Count > 1 &&
                Vector3.Distance(Hero.transform.position, new Vector3(target2.x + offset, 0, target2.z + offset)) > 0.2f)
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
            Hero.transform.position = 
            Vector3.MoveTowards(Hero.transform.position, actualTargetPositint, Time.deltaTime * speed);
        }
    }
    

    /// <summary>
    ///метод поворачивает обьект к цели по Y
    /// </summary>
    public void RotateToTarget(Vector3 target, float speed)
    {
        Vector3 direction = (target - Hero.transform.position).normalized;
        Quaternion locrot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Hero.transform.rotation = Quaternion.Slerp(Hero.transform.rotation, locrot, Time.deltaTime * speed);
    }
}
