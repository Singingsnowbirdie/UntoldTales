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

    public void OnCreate() { }

    public void OnExit() { }

    public void OnStart() { }

}
