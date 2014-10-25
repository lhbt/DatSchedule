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
                if (gameState.StressLevel > 100) 
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
                if (gameState.HungerLevel > 100) gameState.HungerLevel = 100;
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
    }
}