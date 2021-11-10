using UnityEngine;
using UnityEngine.EventSystems;

//скрипт выбора героя на Круге Героев (добавляется в момент создания героев на круге)

public class HeroCircleSelector : MonoBehaviour, IPointerClickHandler
{
    //ID селектора
    public int SelectorID { get; internal set; }

    //уже выбран кем-то
    public bool IsSelected { get; internal set; }

    //круг героев
    public HeroesCircle HeroesCircle { get; internal set; }

    void OnEnable()
    {
        EventManager.OnStageExit += StageExit;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Клик левой кнопкой мыши
        if (eventData.pointerId == -1)
        {
            //если этот герой еще никем не выбран
            if (!IsSelected)
            {
                //сообщаем о выборе
                EventManager.OnHeroSelectedEventInvoke(gameObject.GetComponent<Hero>().Info.Name);
                //помечаем выбранным
                Select();
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
        //удаляем этого героя из коллекции героев в HeroesCircle
        HeroesCircle.RemoveHero(SelectorID);
        //уничтожаем объект
        Destroy(gameObject);
    }

    /// <summary>
    /// Пытаемся выбрать этого героя
    /// </summary>
    /// <returns></returns>
    internal string TryToSelect()
    {
        string heroName = "";
        //если этот герой еще никем не выбран
        if (!IsSelected)
        {
            //запоминаем имя
            heroName = gameObject.GetComponent<Hero>().Info.Name;
            //помечаем героя выбранным 
            Select();
        }
        return heroName;
    }
}
