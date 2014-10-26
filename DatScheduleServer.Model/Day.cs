using System.Collections.Generic;

namespace DatScheduleServer.Model
{
    public class Day
    {
        public Day(int duration)
        {
            Reset(duration);
        }

        public int TimeSpent { get; set; }

        public int Duration { get; set; }

        public List<Task> Tasks { get; set; }

        public void Reset(int duration)
        {
            Duration = duration;
            Tasks = RandomTaskGenerator.GetUniquieSet(GameTasks.ListOfTasks);
            TimeSpent = 0;
        }
    }
}