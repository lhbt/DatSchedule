﻿using System;
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
                new Task("Meal", 1.0, TaskType.Meeting),
                new Task("Leisure", 1.0, TaskType.Leisure)
            };
        }

        public void ProcessTasks(List<Task> tasks)
        {
            if (tasks.Any(x => x.Type == TaskType.Leisure))
            {
                StressLevel = StressLevel - 10;
            }

            if (tasks.Any(x => x.Type == TaskType.Sleep))
            {
                TirednessLevel = TirednessLevel - 60;
            }
        }
    }
}