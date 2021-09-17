using System;
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
    /// Создаем все игровые объекты сцены
    /// </summary>
    public override List<GameObject> CreateAllGameObjects()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Создаем все репозиитории
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();
        //кошелек
        CreateRepository<WalletRepository>(repositoriesMap);
        //инвентарь
        CreateRepository<InventoryRepository>(repositoriesMap);
        return repositoriesMap;
    }

    /// <summary>
    /// Создаем все контроллеры
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, Controller> CreateAllControllers()
    {
        var controllersMap = new Dictionary<Type, Controller>();
        //кошелек
        CreateController<WalletController>(controllersMap);
        //инвентарь
        CreateController<InventoryController>(controllersMap);
        return controllersMap;
    }
}
