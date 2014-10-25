namespace DatScheduleServer.Model
{
    public class GameRulesEnforcer
    {
        public static void ApplyRule(Task task, GameState gameState)
        {
            if (task.Type == TaskType.Leisure)
            {
                gameState.StressLevel -= GameRulesParameters.ImpactOfLeisureOnStress;
                return;
            }

            if (task.Type == TaskType.Sleep)
            {
                gameState.TirednessLevel -= GameRulesParameters.ImpactOfSleepOnTiredness;
                return;
            }

            if (task.Type == TaskType.Meal)
            {
                gameState.HungerLevel -= GameRulesParameters.ImpactOfMealOnHunger;
                return;
            }

            if (task.Type == TaskType.Meeting)
            {
                gameState.HungerLevel += 5;
                gameState.StressLevel += 10;
                gameState.TirednessLevel += 50;
            }
        }
    }
}