using System;

namespace DatSchedule_Server.Model
{
    public interface IGameState
    {
        int StressLevel { get; set; }
        Guid GameId { get; }
        string[] Tasks { get; set; }
        GameState Initialise();
    }

    public class GameState : IGameState
    {
        public int StressLevel { get; set; }

        public Guid GameId { get; set; }

        public string[] Tasks { get; set; }

        public GameState Initialise()
        {
            return new GameState
            {
                GameId = Guid.NewGuid(),
                StressLevel = 50,
                Tasks = new[]
                {
                    "Snack Break",
                    "Toilet Break",
                    "Work Outside",
                    "Sick Day",
                    "Holiday",
                    "Leisure Hour"
                }

            };

        }
    }
}
