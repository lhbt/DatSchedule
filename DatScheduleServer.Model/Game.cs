using System;

namespace DatScheduleServer.Model
{
    public class Game
    {
        private readonly GameRulesEnforcer _gameRules;

        public Game()
        {
            _gameRules = new GameRulesEnforcer();
            CurrentDay = new Day(12);
            Id = Guid.NewGuid();
            GameState = new GameState(0, 0, 0);
        }

        public int CurrentLevel { get; set; }

        public bool EndOfDay { get; set; }

        public bool GameOver { get; set; }

        public Day CurrentDay { get; set; }

        public GameState GameState { get; set; }

        public Guid Id { get; set; }

        public void ProcessTask(Task task)
        {
            _gameRules.ApplyRule(task, GameState);
        }
        
    }
}
