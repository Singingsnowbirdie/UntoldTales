using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RoundController : IController
{
    /// <summary>
    /// Раунд
    /// </summary>
    Round round;

    public void Initialize()
    {
        round = new Round();
    }

    public void OnCreate()
    {
        EventManager.OnChangeRoundStageBttnPressed += ChangeRoundStage;
    }

    public void OnExit()
    {
        EventManager.OnChangeRoundStageBttnPressed -= ChangeRoundStage;
    }

    public void OnStart()
    {
        //throw new NotImplementedException();
    }

    /// <summary>
    /// Сменить фазу раунда
    /// </summary>
    private void ChangeRoundStage()
    {
        round.SetNextStage();
    }
}
