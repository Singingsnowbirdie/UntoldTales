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
        var allRepositories = new Dictionary<Type, Repository>();
        //CreateRepository<HeroesRepository>(repositoriesMap);
        return allRepositories;
    }

    /// <summary>
    /// Создаем все контроллеры
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, IController> CreateAllControllers()
    {
        var allControllers = new Dictionary<Type, IController>();
        CreateController<MatchController>(allControllers);
        CreateController<KeeperController>(allControllers);
        CreateController<SquadController>(allControllers);
        CreateController<InventoryController>(allControllers);
        CreateController<MarketController>(allControllers);
        return allControllers;
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
