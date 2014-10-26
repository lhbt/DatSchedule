using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
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
            Get["/game/{name}"] = parameters =>
            {
                Log("GET CALLED");

                var name = parameters.name;
                var game = new Game();
                game.SetName(name);

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


            Get["/scores"] = parameters =>
            {
                Log("Scores CALLED");

                return Response.AsJson(GetScoreBoard()).WithHeader("Access-Control-Allow-Origin", "*");
            };
        }

        private List<object> GetScoreBoard()
        {

            List<string> keys = new List<string>();
            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();

            var scores = new List<object>();
            while (enumerator.MoveNext())
                keys.Add(enumerator.Key.ToString());

            for (int i = 0; i < keys.Count; i++)
            {
                var game = HttpContext.Current.Cache.Get(keys[i]) as Game;
                if (game != null)
                    scores.Add(new
                    {
                        Name = game.Name == null ? "Anonymous" : game.Name == "null" ? "Anonymous" : game.Name,
                        Score = game.TotalScore

                    });
            }
            return scores;

        }

        private void Log(string message)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(message));
        }
    }
}