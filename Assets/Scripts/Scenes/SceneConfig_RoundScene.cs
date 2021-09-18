﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfig_RoundScene : SceneConfig
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
    public override Dictionary<Type, Controller> CreateAllControllers()
    {
        var controllersMap = new Dictionary<Type, Controller>();
        //CreateController<RoundController>(controllersMap);
        return controllersMap;
    }

    /// <summary>
    /// Инициализатор
    /// </summary>
    public override void Initialize()
    {
        //throw new NotImplementedException();
    }

    /// <summary>
    /// Старт
    /// </summary>
    public override void OnStart()
    {
        //throw new NotImplementedException();
    }

}