using UnityEngine;
using UnityEngine.EventSystems;

public class HeroSelector : MonoBehaviour, IPointerClickHandler
{
    Hero hero;

    public void OnPointerClick(PointerEventData eventData)
    {
        //Клик левой кнопкой мыши
        if (eventData.pointerId == -1)
        {
            EventManager.OnHeroPointedEventInvoke(gameObject.GetComponent<Hero>());
        }
    }
    
}
