using System;
using UnityEngine;
using UnityEngine.EventSystems;

//скрипт выбора героя на Круге Героев (добавляется в момент создания героев на круге)

public class HeroCircleSelector : MonoBehaviour, IPointerClickHandler
{
    //ID героя
    public int HeroID { get; internal set; }

    //уже выбран кем-то
    public bool IsSelected { get; internal set; }

    //можно выбирать героя
    bool IsSelectable = true;

    void OnEnable()
    {
        EventManager.OnStageExit += StageExit;
        EventManager.OnHeroPurchased += HeroPurchased;
    }

    /// <summary>
    /// Игрок выбрал себе героя
    /// </summary>
    private void HeroPurchased(int obj)
    {
        IsSelectable = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsSelectable)
        {
            //Клик левой кнопкой мыши
            if (eventData.pointerId == -1)
            {
                //если этот герой еще никем не выбран
                if (!IsSelected)
                {
                    //сообщаем о выборе
                    EventManager.OnHeroPurchasedEventInvoke(HeroID);
                    //помечаем выбранным
                    Select();
                }
            }
        }
    }

    /// <summary>
    /// Удаляет героя, когда завершился круг героев
    /// </summary>
    private void StageExit(IStage stage)
    {
        if (stage is HeroesCircleStage)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        EventManager.OnStageExit -= StageExit;
    }

    internal void Select()
    {
        //помечаем выбранным
        IsSelected = true;
        //уничтожаем объект
        Destroy(gameObject);
    }

    /// <summary>
    /// Пытаемся выбрать этого героя
    /// </summary>
    /// <returns></returns>
    internal int TryToSelect()
    {
        //если этот герой еще никем не выбран
        if (!IsSelected)
        {
            //помечаем героя выбранным 
            Select();
            //возвращаем его ID
            return HeroID;
        }
        return 0;
    }
}
