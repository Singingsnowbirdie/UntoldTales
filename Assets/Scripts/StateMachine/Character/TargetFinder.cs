using UnityEngine;

//Осуществляет поиск противника
public class TargetFinder 
{
    /// <summary>
    /// Находит ближайшего противника
    /// </summary>
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

    /// <summary>
    /// Исключает "себя" из списка возможных целей
    /// </summary>
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
