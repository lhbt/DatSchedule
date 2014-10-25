using System;

namespace DatSchedule_Server.Model
{
    public interface IGameState
    {
        int StressLevel { get; set; }
        Guid Id { get; }
        string[] Tasks { get; set; }
        GameState Initialise();
    }

    public class GameState : IGameState
    {
        public int StressLevel { get; set; }

        public Guid Id { get; set; }

        public string[] Tasks { get; set; }

        public GameState Initialise()
        {
            return new GameState
            {
                Id = Guid.NewGuid(),
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
