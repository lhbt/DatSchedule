using System;
using System.Collections.Generic;

namespace DatScheduleServer.Model
{
    public class Game
    {
        private TaskProcessor _taskProcessor;

        public Game()
        {
            _taskProcessor = new TaskProcessor();
        }

        public GameState GameState { get; set; }

        public int DayDuration { get; set; }

        public Guid Id { get; set; }

        public List<Task> Tasks { get; set; }

        public void Initialise()
        {
            DayDuration = 12;
            Id = Guid.NewGuid();
            Tasks = CreateTasks();
            GameState = new GameState(0, 0, 0);
        }

        private static List<Task> CreateTasks()
        {
            //at some point should be refactored to generate a list of tasks based on an algorithm and pseudo randomness
            return new List<Task>
            {
                new Task("Team Meeting", 2.0, TaskType.Meeting, "#33CCFF"),
                new Task("Interview", 1.0, TaskType.Meeting, "#33CCFF"),
                new Task("Big Executive Meeting", 3.0, TaskType.Meeting, "#33CCFF"),
                new Task("Meal", 1.0, TaskType.Meal, "#FF6633"),
                new Task("Leisure", 1.0, TaskType.Leisure, "#FFFF33"),
                new Task("Swimming", 1.0, TaskType.Leisure, "#FFFF33"),
                new Task("Retrospective", 2.0, TaskType.Meeting, "#33CCFF"),
                new Task("Code kata", 1.0, TaskType.Meeting, "#33CCFF")
            };
        }

        public void ProcessTask(Task task)
        {
            _taskProcessor.ProcessTask(task, GameState);
        }
        
    }

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
