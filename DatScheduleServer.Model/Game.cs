using System;

namespace DatScheduleServer.Model
{
    public class Game
    {
        public Game()
        {
            CurrentDay = new Day(12);
            Id = Guid.NewGuid();
            GameState = new GameState(100, 100, 100);
            EndOfDay = false;
            GameOver = false;
        }

        public int CurrentLevel { get; set; }

        public bool EndOfDay { get; set; }

        public bool GameOver { get; set; }

        public Day CurrentDay { get; set; }

        public GameState GameState { get; set; }

        public Guid Id { get; set; }
    }
}
