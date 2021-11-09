using UnityEngine;

//Важно! Один и тот же герой разного ранга - это РАЗНЫЕ скриптуемые объекты
//Возможно, стоит сразу добавлять в карточку ссылки на инфо этого же героя, но других рангов (подумать)  


//чтобы вызывать быстро из меню
[CreateAssetMenu(fileName = "HeroInfo", menuName = "Script/HeroInfo")]
public class HeroInfo : CharacterInfo
{
    [Header("Ранг")]
    [SerializeField] private int rank;
    public int Rank => this.rank;

    [Header("Фракция")]
    [SerializeField] Fraction fraction;
    public Fraction Fraction => this.fraction;

    [Header("Класс")]
    [SerializeField] Class heroClass;
    public Class Class => this.heroClass;

    [Header("Максимум маны")]
    [SerializeField] int maxMana;
    public int MaxMana => this.maxMana;

    [Header("Имет ульту?")]
    [SerializeField] bool hasUltimateAbility;
    public bool HasUltimateAbility => this.hasUltimateAbility;

    [Header("Максимальное значение энергии (для героев, имеющих ульту)")]
    [SerializeField] int maxEnergy;
    public int MaxEnergy => this.maxEnergy;

    [Header("Сколько энергии герой получает за одну атаку по цели (для героев, имеющих ульту)")]
    [SerializeField] int energyStorageRate;
    public int EnergyStorageRate => this.energyStorageRate;

    [Header("Иконка")]
    [SerializeField] Sprite sprite;
    public Sprite Sprite => this.sprite;
}



