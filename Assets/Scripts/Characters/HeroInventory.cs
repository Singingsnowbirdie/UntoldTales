using System.Collections.Generic;

public class HeroInventory
{
    /// <summary>
    /// Суммарная стоимость всех экипированных предметов (в единицах)
    /// </summary>
    public int EquipmentСost { get; set; }

    /// <summary>
    /// Используется при слиянии (повышении ранга героя)
    /// "Снимает" с героя все надетые на него предметы
    /// Передает их во временный рюкзак
    /// </summary>
    /// <returns></returns>
    internal List<Item> TakeOffAllItems()
    {
        //дописать
        return new List<Item>();
    }
}