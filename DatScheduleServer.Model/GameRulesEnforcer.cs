namespace DatScheduleServer.Model
{
    public class GameRulesEnforcer
    {
        public static void ApplyRule(Task task, GameState gameState, Day currentDay)
        {
            var taskDuration = task.Duration;
            currentDay.TimeSpent += taskDuration;
            gameState.DayIsOver = false;
            if (currentDay.TimeSpent == currentDay.Duration)
            {
                gameState.DayIsOver = true;
                currentDay.Reset(currentDay.Duration);
            }
            
            if (task.Type == TaskType.Leisure)
            {
                gameState.StressLevel += GameRulesParameters.ImpactOfLeisureOnStress;
                if (gameState.StressLevel > 100) gameState.StressLevel = 100;
                return;
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
                if (gameState.HungerLevel > 100) gameState.HungerLevel = 100;
                return;
            }

            if (task.Type == TaskType.Meeting)
            {
                gameState.HungerLevel -= (GameRulesParameters.ImpactOfMeetingOnHunger * taskDuration);
                if (gameState.HungerLevel < 0) gameState.HungerLevel = 0;
                gameState.StressLevel -= (GameRulesParameters.ImpactOfMeetingOnStress * taskDuration);
                if (gameState.StressLevel < 0) gameState.StressLevel = 0;
                gameState.FatigueLevel -= (GameRulesParameters.ImpactOfMeetingOnFatigue * taskDuration);
                if (gameState.FatigueLevel < 0) gameState.FatigueLevel = 0;
            }
        }
    }
}