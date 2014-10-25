namespace DatScheduleServer.Model
{
    public class TaskProcessor
    {
        public void ProcessTask(Task task, GameState gameState)
        {
            if (task.Type == TaskType.Leisure)
            {
                gameState.StressLevel = gameState.StressLevel - GameRulesParameters.ImpactOfLeisureOnStress;
            }

            if (task.Type == TaskType.Sleep)
            {
                gameState.TirednessLevel = gameState.TirednessLevel - GameRulesParameters.ImpactOfSleepOnTiredness;
            }

            if (task.Type == TaskType.Meal)
            {
                gameState.HungerLevel = gameState.HungerLevel - GameRulesParameters.ImpactOfMealOnHunger;
            }
        }
    }
}