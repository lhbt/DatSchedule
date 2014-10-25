using System;
using System.Web;
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
                Log("GET CALLED");

                var game = new GameState();
                game.Initialise();

                HttpContext.Current.Cache.Insert("Game-" + game.GameId, game);

                return Response.AsJson(game).WithHeader("Access-Control-Allow-Origin", "*");
            };

            Post["/post"] = parameters =>
            {
                Log("POST CALLED");
                return "Application initiated";
            };
        }

        private void Log(string message)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(message));
        }
    }
}