using System;
using System.IO;
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
                game.Initialise();

                HttpContext.Current.Cache.Insert("Game-" + game.Id, game);

                return Response.AsJson(game).WithHeader("Access-Control-Allow-Origin", "*");
            };

            Post["/update/{id}"] = parameters =>
            {
                Log("POST CALLED");

                var id = parameters.id;

                var currentGame = HttpContext.Current.Cache.Get("Game-" + id) as Game;

                var task = JsonConvert.DeserializeObject<Task>(Request.Body.AsString());
                if (currentGame != null)
                    currentGame.ProcessTask(task);

                return Response.AsJson(currentGame).WithHeader("Access-Control-Allow-Origin", "*");
            };
        }

        private void Log(string message)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(message));
        }
    }
}