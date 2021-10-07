using UnityEngine;
using UnityEngine.EventSystems;

public class HeroSelector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //Клик левой кнопкой мыши
        if (eventData.pointerId == -1)
        {
            EventManager.OnHeroPointedEventInvoke(gameObject.GetComponent<Hero>());
        }
    }
}
