using System.Linq;

namespace DatScheduleServer.Model
{
    public class GameRulesEnforcer
    {
        public static void ApplyRule(Task task, Game game)
        {
            var bob = game.CurrentDay.Tasks.FirstOrDefault(x => x.Equals(task));
            if (bob != null)
            {
                bob.Scheduled = true;
            }
            var taskDuration = task.Duration;

            var currentDay = game.CurrentDay;
            var gameState = game.GameState;

            currentDay.TimeSpent += taskDuration;
            gameState.DayIsOver = false;

            if (currentDay.TimeSpent == currentDay.Duration)
            {
                game.CurrentLevel++;
                gameState.DayIsOver = true;
                currentDay.Reset(currentDay.Duration);
            }

            if (task.Type == TaskType.Leisure)
            {
                gameState.StressLevel += GameRulesParameters.ImpactOfLeisureOnStress;
                if (HasMaxValue(gameState.StressLevel))
                    gameState.StressLevel = 100;
            }

            if (task.Type == TaskType.Sleep)
            {
                gameState.FatigueLevel += GameRulesParameters.ImpactOfSleepOnFatigue;
                if (gameState.FatigueLevel > 100) gameState.FatigueLevel = 100;
                return;
            }

            if (task.Type == TaskType.Meal)
            {
                gameState.HungerLevel += GameRulesParameters.ImpactOfMealOnHunger;
                if (HasMaxValue(gameState.HungerLevel)) gameState.HungerLevel = 100;
            }

            if (task.Type == TaskType.Meeting)
            {
                gameState.HungerLevel -= (GameRulesParameters.ImpactOfMeetingOnHunger * taskDuration);
                gameState.StressLevel -= (GameRulesParameters.ImpactOfMeetingOnStress * taskDuration);
                gameState.FatigueLevel -= (GameRulesParameters.ImpactOfMeetingOnFatigue * taskDuration);
            }

            if (gameState.HungerLevel <= 0 || gameState.FatigueLevel <= 0 || gameState.StressLevel <= 0)
                game.GameOver = true;
        }

        private static bool HasMaxValue(int level)
        {
            return level > 100;
        }
    }
}