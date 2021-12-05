using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchScene : Scene
{
    /// <summary>
    /// Создаем контроллеры
    /// </summary>
    public override void CreateControllers()
    {
        //инициализируем коллекцию контроллеров
        controllers = new Dictionary<Type, IController>();

        //контроллер всего матча
        CreateController<MatchController>(controllers);
        //контроллер отряда
        CreateController<SquadController>(controllers);
        //контроллер магазина
        CreateController<MarketController>(controllers);
    }

    protected override void Start()
    {
        SquadController.Scene = this;
        MarketController.Scene = this;
        
        base.Start();
    }
}
