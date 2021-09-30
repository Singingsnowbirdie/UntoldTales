using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfig_MatchScene : SceneConfig
{
    /// <summary>
    /// Название сцены (константа)
    /// </summary>
    public const string SCENENAME = "RoundScene";

    /// <summary>
    /// Название сцены (свойство)
    /// </summary>
    public override string SceneName => SCENENAME;

    /// <summary>
    /// Создаем все репозитории
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();
        //пример
        //CreateRepository<WalletRepository>(repositoriesMap);
        return repositoriesMap;
    }

    /// <summary>
    /// Создаем все контроллеры
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, IController> CreateAllControllers()
    {
        var controllersMap = new Dictionary<Type, IController>();
        CreateController<MatchController>(controllersMap);
        CreateController<RoundController>(controllersMap);
        CreateController<KeeperController>(controllersMap);
        CreateController<SquadController>(controllersMap);
        CreateController<InventoryController>(controllersMap);
        CreateController<MarketController>(controllersMap);
        return controllersMap;
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    public override void Initialize() { }

    /// <summary>
    /// Старт
    /// </summary>
    public override void OnStart() { }
}
