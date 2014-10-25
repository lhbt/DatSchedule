using System;
using DatSchedule_Server.Model;
using Nancy;
using StructureMap;

namespace DatSchedule_Server
{
    public class IndexModule : BaseHandlerModule
    {
        public IndexModule()
        {
            Get["/game"] = parameters =>
            {
                var game = ObjectFactory.GetInstance<IGameState>();


                return this.Response.AsJson(game.Initialise()).WithHeader("Access-Control-Allow-Origin", "*");
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