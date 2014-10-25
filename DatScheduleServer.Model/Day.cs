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

        private List<Task> CreateTasks()
        {
            //at some point should be refactored to generate a list of tasks based on an algorithm and pseudo randomness
            return new List<Task>
            {
                new Task("Team Meeting", 2, TaskType.Meeting, "#33CCFF"),
                new Task("Interview", 1, TaskType.Meeting, "#33CCFF"),
                new Task("Big Executive Meeting", 3, TaskType.Meeting, "#33CCFF"),
                new Task("Meal", 1, TaskType.Meal, "#FF6633"),
                new Task("Leisure", 1, TaskType.Leisure, "#FFFF33"),
                new Task("Swimming", 1, TaskType.Leisure, "#FFFF33"),
                new Task("Retrospective", 2, TaskType.Meeting, "#33CCFF"),
                new Task("Code kata", 1, TaskType.Meeting, "#33CCFF")
            };
        }

        public void Reset(int duration)
        {
            Duration = duration;
            Tasks = CreateTasks();
            TimeSpent = 0;
        }
    }
}