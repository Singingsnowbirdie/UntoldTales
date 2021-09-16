using System;
using System.Collections.Generic;

//Пример реализации конфига сцены

public class SceneConfigExample : SceneConfig
{
    /// <summary>
    /// Название сцены (константа)
    /// </summary>
    public const string SCENENAME = "Example Scene";

    /// <summary>
    /// Название сцены (свойство)
    /// </summary>
    public override string SceneName => SCENENAME;

    /// <summary>
    /// Создаем карту репозиториев
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();
        CreateRepository<WalletRepository>(repositoriesMap);
        return repositoriesMap;
    }

    /// <summary>
    /// Создаем карту контроллеров
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, Controller> CreateAllControllers()
    {
        var controllersMap = new Dictionary<Type, Controller>();

        CreateController<WalletController>(controllersMap);
        CreateController<PlayerController>(controllersMap);

        return controllersMap;
    }
}
