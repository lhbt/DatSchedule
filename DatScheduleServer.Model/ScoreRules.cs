namespace DatScheduleServer.Model
{
    public class ScoreRules
    {
        public static void Apply(Task task, Game game)
        {
            game.TotalScore += 10;
            if (task.Type == TaskType.Meeting)
            {
                game.TotalScore += 20;
                if(task.Duration == 2)
                    game.TotalScore+=10;
                if (task.Duration > 2)
                    game.TotalScore += 20;
            }

            if (task.Type == TaskType.Sleep)
            {
                game.TotalScore += 10;
                if (task.Duration == 2)
                    game.TotalScore += 10;
                if (task.Duration > 2)
                    game.TotalScore += 15;
            }
        }
    }
}