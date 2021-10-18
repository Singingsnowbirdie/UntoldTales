using UnityEngine;
using UnityEngine.EventSystems;

//скрипт выбора героя на Круге Героев

public class HeroCircleSelector : MonoBehaviour, IPointerClickHandler
{
    //уже выбран кем-то
    public bool IsSelected { get; set; }

    //доступен для выбора игроком
    bool isAvailableForPlayer = true;
    public bool IsAvailableForPlayer { get => isAvailableForPlayer; set => isAvailableForPlayer = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Клик левой кнопкой мыши
        if (eventData.pointerId == -1)
        {
            //если этот герой еще никем не выбран
            if (!IsSelected && IsAvailableForPlayer)
            {
                //запрещаем выбирать
                IsAvailableForPlayer = false;
                //помечаем выбранным
                IsSelected = true;
                //находим основной скрипт
                Hero hero = gameObject.GetComponent<Hero>();
                //сообщаем имя выбранного героя
                EventManager.OnHeroSelectedEventInvoke(hero.Info.Name);
                //уничтожаем объект (временно)
                //потом этот герой будет уничтожаться не сразу, а только после того, как Хранитель "заберет" его
                Destroy(gameObject);
            }
        }
    }
}
