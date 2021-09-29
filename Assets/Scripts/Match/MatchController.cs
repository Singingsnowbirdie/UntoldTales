using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : Controller
{
    /// <summary>
    /// Текущий матч
    /// </summary>
    Match match;

    public override void Initialize()
    {
        base.Initialize();
        match = new Match();
        match.AddPlayers();
        EventManager.OnChangeMatchStageBttnPressed += ChangeMatchStage;
    }

    public override void OnExit()
    {
        base.OnExit();
        EventManager.OnChangeMatchStageBttnPressed -= ChangeMatchStage;
    }

    /// <summary>
    /// Сменить стадию
    /// </summary>
    private void ChangeMatchStage()
    {
        match.SetNextStage();
    }
}
