using System;
using System.Collections.Generic;

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
    /// Создаем карту интеракторов
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<WalletInteractor>(interactorsMap);
        CreateInteractor<PlayerInteractor>(interactorsMap);

        return interactorsMap;
    }
}
