using System;
using UnityEngine;
using UnityEngine.EventSystems;

//Этот скрипт используется только для выбора героя на круге героев

//Этот скрипт позволяет "отловить" клик по объекту, на котором висит
//Важно: Чтобы этот скрипт работал, на камере должен висеть компонент PhysicsRaycaster (это скрипт)
//Важно: На сцене должен присутствовать объект EventSystem
//Само собой, на объекте должен быть коллайдер. При этом, если это меш-коллайдер, то он должен быть не конвексом.

public class HeroSelector : MonoBehaviour, IPointerClickHandler
{
    //живой игрок выбрал себе героя
    bool isPlayerSelected;

    public HeroSelector()
    {
        //подписываемся на выбор героя
        //чтобы знать, что живой игрок уже выбрал себе героя
        EventManager.OnHeroSelected += OnHeroSelected;
        isPlayerSelected = false;
    }

    private void OnHeroSelected(Hero hero, int heroID)
    {
        //если живой игрок выбрал себе героя, блокируем клики по всем остальным
        if (heroID == 0)
        {
            EventManager.OnHeroSelected -= OnHeroSelected;
            isPlayerSelected = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Клик левой кнопкой мыши
        if (eventData.pointerId == -1 && !isPlayerSelected)
        {
            Select();
        }
    }

    /// <summary>
    /// Живой игрок выбрал себе героя
    /// </summary>
    internal void Select()
    {
        EventManager.OnHeroSelectedEventInvoke(gameObject.GetComponent<Hero>(), 0);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// AI выбрал себе героя
    /// </summary>
    /// <param name="heroID"></param>
    internal void Select(int heroID)
    {
        EventManager.OnHeroSelectedEventInvoke(gameObject.GetComponent<Hero>(), heroID);
        gameObject.SetActive(false);
    }
}
