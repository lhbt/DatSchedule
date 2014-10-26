using System;

namespace DatScheduleServer.Model
{
    public class Game
    {
        public Game()
        {
            CurrentDay = new Day(9);
            Id = Guid.NewGuid();
            GameState = new GameState(100, 100, 100);
            GameOver = false;
            CurrentLevel = 1;
            TotalScore = 0;
        }

        public string Message { get; set; }

        public int CurrentLevel { get; set; }

        public bool GameOver { get; set; }

        public Day CurrentDay { get; set; }

        public GameState GameState { get; set; }

        public Guid Id { get; set; }

        public int TotalScore { get; set; }

        public void SetName(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
