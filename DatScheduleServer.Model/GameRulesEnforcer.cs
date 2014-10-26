using System.Linq;

namespace DatScheduleServer.Model
{
    public class GameRulesEnforcer
    {
        public static void ApplyRule(Task task, Game game)
        {
            ScoreRules.Apply(task, game);
            var matchingTask = game.CurrentDay.Tasks.FirstOrDefault(x => x.Equals(task));
            if (matchingTask != null)
            {
                matchingTask.SetScheduled();
            }

            var taskDuration = task.Duration;
            var currentDay = game.CurrentDay;
            var gameState = game.GameState;

            currentDay.TimeSpent += taskDuration;
            gameState.DayIsOver = false;


            if (currentDay.TimeSpent == currentDay.Duration)
            {
                game.Message = GameMessages.YouSurvivedAnotherDay;
                TriggerNight(game, gameState, currentDay);
            }

            if (!game.CurrentDay.Tasks.Any(x => x.Duration <= (currentDay.Duration - currentDay.TimeSpent)))
            {
                game.Message = GameMessages.WorkingAfter5PmYouFool;
                TriggerNight(game, gameState, currentDay);
                //Extra penataly for working late. SUCKER !
                gameState.FatigueLevel = gameState.FatigueLevel.DecreaseValue(-10);
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

            if (gameState.HungerLevel <= 0)
            {
                game.GameOver = true;
                game.Message = GameMessages.CharacterDiedOfHunger;
            }

            if (gameState.FatigueLevel <= 0)
            {
                game.GameOver = true;
                game.Message = GameMessages.CharacterDiedOfFatigue;
            }

            if (gameState.StressLevel <= 0)
            {
                game.GameOver = true;
                game.Message = GameMessages.CharacterDiedOfHeartAttack;
            }

        }

        private static void TriggerNight(Game game, GameState gameState, Day currentDay)
        {
            game.CurrentLevel++;
            gameState.DayIsOver = true;
            gameState.FatigueLevel = gameState.FatigueLevel.IncreaseValue(45);
            gameState.StressLevel = gameState.StressLevel.IncreaseValue(15);
            gameState.HungerLevel = gameState.HungerLevel.IncreaseValue(10);
            currentDay.PopulateNextDayData(currentDay.Duration);
        }
    }
}