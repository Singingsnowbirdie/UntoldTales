using UnityEngine;

/// <summary>
///  класс занимается поиском противников
/// </summary>
public class FindTarget 
{
    //поиск ближайшего противника
    public void FindNearestTarget(Character character)
    {
        Transform enemyPos = Findmyself(character);

        foreach (var item in TestBankHeroes.EnemiesOnAren)
        {
            if (item.Value.transform.gameObject != character.transform.gameObject)
            {
                if (Vector3.Distance(enemyPos.position, character.transform.position) > 
                    Vector3.Distance(item.Value.transform.position, character.transform.position))
                {
                    enemyPos = item.Value.transform;
                }
            }
        }
        character.CurrentTarget = enemyPos.GetComponent<Hero>();
    }

    //метод исключает себя из списка целей
    private Transform Findmyself(Character character)
    {
        Character[] HeroTrans = GameObject.FindObjectsOfType<Hero>() ;
        foreach (var item in HeroTrans)
        {
            if(item.transform.gameObject != character.transform.gameObject)
            {
                return item.transform;
            }
        }
        return null;
    }
}
