using System;
using System.Collections.Generic;

public class MatchScene : SceneConfig
{
    /// <summary>
    /// Создаем все репозитории
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, Repository> CreateRepositories()
    {
        return new Dictionary<Type, Repository>();
    }

    /// <summary>
    /// Создаем все контроллеры
    /// </summary>
    /// <returns></returns>
    public override Dictionary<Type, IController> CreateControllers()
    {
        var conrollers = new Dictionary<Type, IController>();

        CreateController<MatchController>(conrollers);
        CreateController<MarketController>(conrollers);
        //CreateController<KeeperController>(conrollers);
        //CreateController<SquadController>(conrollers);
        //CreateController<InventoryController>(conrollers);

        return conrollers;
    }
}
