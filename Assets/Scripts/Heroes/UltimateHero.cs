using UnityEngine;

//Этот герой умеет накапливать энергию, имеет ульту

public class UltimateHero : Hero
{
    /// <summary>
    /// Следующая атака - ульта?
    /// </summary>
    bool IsUltimateAttack;

    /// <summary>
    /// Атака
    /// </summary>
    public override void Attack()
    {
        base.Attack();
        if (IsUltimateAttack)
        {
            UltimateAttack();
        }
        else
        {
            OrdinaryAttack();
        }
        IsUltimateAttack = stats.AddEnergy();
    }

    /// <summary>
    /// Обычная атака
    /// </summary>
    void OrdinaryAttack()
    {
        Debug.Log("OrdinaryAttack");
    }

    /// <summary>
    /// Атака ультой
    /// </summary>
    void UltimateAttack()
    {
        IsUltimateAttack = false;
        Debug.Log("UltimateAttack");
    }


}
