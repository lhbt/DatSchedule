using System;
using System.Collections.Generic;
using System.Linq;

namespace DatScheduleServer.Model
{
    public class Game
    {
        public int StressLevel { get; set; }
        public int TirednessLevel { get; set; }
        public int HungerLevel { get; set; }

        public int DayDuration { get; set; }

        public Guid Id { get; set; }

        public List<Task> Tasks { get; set; }

        public void Initialise()
        {
            DayDuration = 8;
            Id = Guid.NewGuid();
            StressLevel = 10;
            HungerLevel = 0;
            TirednessLevel = 0;
            Tasks = CreateTasks();
        }

        private static List<Task> CreateTasks()
        {
            return new List<Task>
            {
                new Task("Team Meeting", 2.0, TaskType.Meeting),
                new Task("Interview", 1.0, TaskType.Meeting),
                new Task("Big Executive Meeting", 3.0, TaskType.Meeting),
                new Task("Meal", 1.0, TaskType.Meal),
                new Task("Leisure", 1.0, TaskType.Leisure)
            };
        }

        public void ProcessTask(Task task)
        {
            if (task.Type == TaskType.Leisure)
            {
                StressLevel = StressLevel - GameRulesParameters.ImpactOfLeisureOnStress;
            }

            if (task.Type == TaskType.Sleep)
            {
                TirednessLevel = TirednessLevel - GameRulesParameters.ImpactOfSleepOnTiredness;
            }

            if (task.Type == TaskType.Meal)
            {
                HungerLevel = HungerLevel - GameRulesParameters.ImpactOfMealOnHunger;
            }
        }
    }
}
