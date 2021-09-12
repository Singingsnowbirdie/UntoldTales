using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfigExample : SceneConfig
{

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
        return interactorsMap;
    }
}
