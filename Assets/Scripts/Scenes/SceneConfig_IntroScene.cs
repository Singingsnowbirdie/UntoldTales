using System;
using System.Collections.Generic;
using UnityEngine;

//Нулевая сцена

internal class SceneConfig_IntroScene : SceneConfig
{
    /// <summary>
    /// Название сцены (константа)
    /// </summary>
    public const string SCENENAME = "IntroScene";

    /// <summary>
    /// Название сцены (свойство)
    /// </summary>
    public override string SceneName => SCENENAME;

    /// <summary>
    /// Создаем все репозиитории
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
    public override Dictionary<Type, Controller> CreateAllControllers()
    {
        var controllersMap = new Dictionary<Type, Controller>();
        //пример
        //CreateController<WalletController>(controllersMap);
        return controllersMap;
    }

    /// <summary>
    /// Старт
    /// </summary>
    public override void OnStart()
    {
        throw new NotImplementedException();
    }

    public override void Initialize()
    {
        throw new NotImplementedException();
    }
}