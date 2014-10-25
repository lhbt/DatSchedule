using System;
using DatSchedule_Server.Model;
using Nancy;

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

                return this.Response.AsJson(gameState).WithHeader("Access-Control-Allow-Origin", "*");
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