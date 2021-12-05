using System;
using System.Collections.Generic;
using UnityEngine;

//панелька магазина героев

public class HeroesMarketPanel : MonoBehaviour
{
    /// <summary>
    /// Карточки героев
    /// </summary>
    HeroMarketCard[] heroMarketCards;

    /// <summary>
    /// Визуал временного хранилища
    /// </summary>
    TemporaryStoragePanel temporaryStorage;

    private void OnEnable()
    {
        //если карточки не инициализированы
        if (heroMarketCards == null)
        {
            heroMarketCards = GetComponentsInChildren<HeroMarketCard>();
            EventManager.OnMarketAssortmentChanged += ShowNewAssortment;
        }

        //если панель временного хранилища не определена
        if (temporaryStorage == null)
        {
            temporaryStorage = gameObject.GetComponentInChildren<TemporaryStoragePanel>();
        }

        //при каждом открытии магазина, проверяем статус временного хранилища
        temporaryStorage.CheckStatus();
    }

    /// <summary>
    /// Показывает карточки нового ассортимента
    /// </summary>
    private void ShowNewAssortment(List<CharacterInfo> characters)
    {
    }
}
