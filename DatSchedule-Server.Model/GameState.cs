using System;

namespace DatSchedule_Server.Model
{
    public interface IGameState
    {
        int StressLevel { get; set; }
        Guid ApplicationId { get; }
        string[] Tasks { get; set; }
        GameState Initialise();
    }

    public class GameState : IGameState
    {
        public int StressLevel { get; set; }

        public Guid ApplicationId
        {
            get { return Guid.NewGuid(); }
        }

        public string[] Tasks { get; set; }

        public GameState Initialise()
        {
            return new GameState
            {
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
