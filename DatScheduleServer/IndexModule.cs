using System;
using System.Web;
using DatScheduleServer.Model;
using Nancy;
using Nancy.Extensions;
using Newtonsoft.Json;

namespace DatScheduleServer
{
    public class IndexModule : BaseHandlerModule
    {
        public IndexModule()
        {
            Get["/game"] = parameters =>
            {
                Log("GET CALLED");

                var game = new Game();

                HttpContext.Current.Cache.Insert("Game-" + game.Id, game);

                return Response.AsJson(game).WithHeader("Access-Control-Allow-Origin", "*");
            };

            Post["/update/{id}"] = parameters =>
            {
                Log("POST CALLED");

                var id = parameters.id;

                var currentGame = HttpContext.Current.Cache.Get("Game-" + id) as Game;

                if (currentGame == null)
                {
                  throw new Exception("Game Not initialised please re-run.");
                }

                var task = JsonConvert.DeserializeObject<Task>(Request.Body.AsString());

                GameRulesEnforcer.ApplyRule(task, currentGame);

                return Response.AsJson(currentGame).WithHeader("Access-Control-Allow-Origin", "*");
            };
        }

        private void Log(string message)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(message));
        }
    }
}