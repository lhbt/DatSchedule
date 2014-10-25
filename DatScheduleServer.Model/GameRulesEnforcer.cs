namespace DatScheduleServer.Model
{
    public class GameRulesEnforcer
    {
        public static void ApplyRule(Task task, GameState gameState, Day currentDay)
        {
            currentDay.TimeSpent += task.Duration;
            gameState.DayIsOver = false;
            if (currentDay.TimeSpent == currentDay.Duration)
            {
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
                gameState.TirednessLevel += GameRulesParameters.ImpactOfSleepOnTiredness;
                if (gameState.TirednessLevel > 100) gameState.TirednessLevel = 100;
            }

            if (task.Type == TaskType.Meal)
            {
                gameState.HungerLevel += GameRulesParameters.ImpactOfMealOnHunger;
                if (HasMaxValue(gameState.HungerLevel)) gameState.HungerLevel = 100;
            }

            if (task.Type == TaskType.Meeting)
            {
                gameState.HungerLevel -= 5;
                if (gameState.HungerLevel < 0) gameState.HungerLevel = 0;
                gameState.StressLevel -= 10;
                if (gameState.StressLevel < 0) gameState.StressLevel = 0;
                gameState.TirednessLevel -= 10;
                if (gameState.TirednessLevel < 0) gameState.TirednessLevel = 0;
            }
        }

        private static bool HasMaxValue(int level)
        {
            return level > 100;
        }
    }
}