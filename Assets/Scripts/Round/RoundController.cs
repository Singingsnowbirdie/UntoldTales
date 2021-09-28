using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RoundController : Controller
{
    /// <summary>
    /// Раунд
    /// </summary>
    Round round;

    public override void Initialize()
    {
        base.Initialize();
        round = new Round();
        EventManager.OnChangeRoundStageBttnPressed += ChangeRoundStage;
    }

    public override void OnExit()
    {
        base.OnExit();
        EventManager.OnChangeRoundStageBttnPressed -= ChangeRoundStage;
    }

    /// <summary>
    /// Сменить фазу раунда
    /// </summary>
    private void ChangeRoundStage()
    {
        round.SetNextStage();
    }
}
