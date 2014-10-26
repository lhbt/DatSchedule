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
                gameState.FatigueLevel += 40;
                currentDay.Reset(currentDay.Duration);
            }

            if (task.Type == TaskType.Leisure)
            {
                gameState.StressLevel = gameState.StressLevel.IncreaseValue(GameRulesParameters.ImpactOfLeisureOnStress);
                return;
            }

            if (task.Type == TaskType.Sleep)
            {
                gameState.FatigueLevel = gameState.FatigueLevel.IncreaseValue(GameRulesParameters.ImpactOfSleepOnFatigue);
                return;
            }

            if (task.Type == TaskType.Meal)
            {
                gameState.HungerLevel = gameState.HungerLevel.IncreaseValue(GameRulesParameters.ImpactOfMealOnHunger);
                return;
            }

            if (task.Type == TaskType.Meeting)
            {
                gameState.HungerLevel = gameState.HungerLevel.DecreaseValue(GameRulesParameters.ImpactOfMeetingOnHunger * taskDuration);
                gameState.StressLevel = gameState.StressLevel.DecreaseValue(GameRulesParameters.ImpactOfMeetingOnStress * taskDuration);
                gameState.FatigueLevel = gameState.FatigueLevel.DecreaseValue(GameRulesParameters.ImpactOfMeetingOnFatigue * taskDuration);
            }

            if (gameState.HungerLevel <= 0 || gameState.FatigueLevel <= 0 || gameState.StressLevel <= 0)
                game.GameOver = true;
        }
    }
}