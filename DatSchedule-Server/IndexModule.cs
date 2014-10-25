using System;
using System.Web.UI.WebControls;
using DatSchedule_Server.Model;
using Newtonsoft.Json;

namespace DatSchedule_Server
{
    public class IndexModule : BaseHandlerModule
    {
        public IndexModule()
        {
            Get["/game"] = parameters =>
            {
                var gameState = new GameState
                {
                    StressLevel = 50
                };

                return JsonConvert.SerializeObject(gameState);
            };

            Post["/init"] = parameters =>
            {
                Log();
                return "Application initiated";
            };
        }

        private void Log()
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("Test Exception"));
        }
    }
}