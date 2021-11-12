using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс, производящий слияние трех одинаковых героев, с повышением ранга

public class Merger : MonoBehaviour
{
    //отряд
    private Squad squad;

    /// <summary>
    /// Три одинаковых героя для слияния
    /// </summary>
    List<Hero> trine;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Merger(Squad squad)
    {
        this.squad = squad;
        trine = new List<Hero>();
    }

    /// <summary>
    /// Проверяет, имеется ли у игрока три одинаковых героя
    /// </summary>
    public bool ThereAreThree(GameObject heroGO)
    {
        //добавляем в трин
        trine.Add(heroGO.GetComponent<Hero>());
        //если есть еще два таких же на поле, мерджим
        if (FindTheSame(squad.heroesOnTheField)) return true;
        //иначе продолжаем поиск в резерве
        else if (FindTheSame(squad.heroesInReserve)) return true;
        //иначе очищаем трин
        trine.Clear();
        return false;
    }

    /// <summary>
    /// Ищет одинаковых героев в коллекции
    /// Добавляет их в трин
    /// </summary>
    private bool FindTheSame(List<Hero> heroesList)
    {
        foreach (var item in heroesList)
        {
            if (item.Info.Name == trine[0].Info.Name && item.Info.Rank == trine[0].Info.Rank)
            {
                trine.Add(item);
                if (trine.Count == 3)
                {
                    Merge();
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Производит слияние трех героев
    /// </summary>
    private void Merge()
    {
        //герой, которого будем улучшать
        Hero heroToMerge = HeroToMerge();
        //улучшаем выбранного героя и удаляем двух оставшихся
        foreach (var item in trine)
        {
            if (item == heroToMerge)
            {
                heroToMerge.Raise(CreateBackpack());
            }
            else
            {
                //пробуем удалить с поля
                if (squad.RemoveHeroFromList(item, squad.heroesOnTheField))
                {
                    EventManager.OnSomethingChangedEventInvoke(squad.heroesOnTheField.Count, Changeable.Field);
                }
                //если герой не нашелся на поле, значит он был в резерве
                else if (squad.RemoveHeroFromList(item, squad.heroesInReserve))
                {
                    EventManager.OnSomethingChangedEventInvoke(squad.heroesInReserve.Count, Changeable.Reserve);
                }
            }
        }
        trine.Clear();
    }

    /// <summary>
    /// Создает временный "рюкзак" и помещает в него все, что надето на героях, которые будут объединены
    /// </summary>
    /// <returns></returns>
    private List<Item> CreateBackpack()
    {
        List<Item> backpack = new List<Item>();
        //снимаем с героев все, что на них надето, и складываем в "рюкзак"
        foreach (var item in trine)
        {
            backpack.AddRange(item.Inventory.TakeOffAllItems());
        }
        return backpack;
    }

    /// <summary>
    /// Определяет наиболее актуального героя для слияния
    /// </summary>
    /// <returns></returns>
    private Hero HeroToMerge()
    {
        Hero heroToMerge = trine[0];
        //стоимость экипировки
        int equipmentCost = trine[0].Inventory.EquipmentСost;
        //выбираем героя, который экипирован богаче
        foreach (var item in trine)
        {
            if (item.Inventory.EquipmentСost > equipmentCost)
            {
                equipmentCost = item.Inventory.EquipmentСost;
                heroToMerge = item;
            }
        }
        //если герои не экипированы
        if (equipmentCost == 0)
        {
            //Если один из героев стоит на поле, то выбираем для улучшения его
            foreach (var item in trine)
            {
                if (item.StateMachine.CurrentStage is IdleStage)
                {
                    heroToMerge = item;
                }
            }
        }
        return heroToMerge;
    }

}
