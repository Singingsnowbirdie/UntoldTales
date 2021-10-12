using UnityEngine;

/// <summary>
///  класс занимается поиском противников
/// </summary>
public class FindTarget 
{
    //поиск ближайшего противника
    public void FindNearestTarget(Hero hero)
    {
        Transform enemyPos = Findmyself(hero);

        foreach (var item in TestBankHeroes.EnemiesOnAren)
        {
            if (item.Value.transform.gameObject != hero.transform.gameObject)
            {
                if (Vector3.Distance(enemyPos.position, hero.transform.position) > 
                    Vector3.Distance(item.Value.transform.position, hero.transform.position))
                {
                    enemyPos = item.Value.transform;
                }
            }
        }
        hero.CurrentTarget = enemyPos.GetComponent<Hero>();
    }

    //метод исключает себя из списка целей
    private Transform Findmyself(Hero hero)
    {
        Hero[] HeroTrans = GameObject.FindObjectsOfType<Hero>() ;
        foreach (var item in HeroTrans)
        {
            if(item.transform.gameObject != hero.transform.gameObject)
            {
                return item.transform;
            }
        }
        return null;
    }
}
