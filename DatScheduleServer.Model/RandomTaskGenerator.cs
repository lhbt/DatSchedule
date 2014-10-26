using System;
using System.Collections.Generic;
using System.Linq;

namespace DatScheduleServer.Model
{
    public static class RandomTaskGenerator
    {
        public static List<Task> GetUniqueSet(List<Task> listOfTasks, List<Task> leftOverTasks)
        {
            var randomTaskList = leftOverTasks.Where(task => !task.Scheduled).ToList();

            return PopulateTasksList(randomTaskList);
        }

        private static List<Task> PopulateTasksList(List<Task> tasks)
        {
            if (tasks.Count == 9)
                return tasks;

            var rand = new Random();

            var staticTasks = GameTasks.ListOfTasks;
            staticTasks.Shuffle();

            var threeHoursMeetings = GameTasks.ListOfTasks.Where(x => x.Type == TaskType.Meeting && x.Duration == 3 && !tasks.Contains(x)).ToList();
            tasks.AddRange(threeHoursMeetings.Take(rand.Next(0,1)));

            if (tasks.Count == 9)
                return tasks;

            var twoHoursMeetings = GameTasks.ListOfTasks.Where(x => x.Type == TaskType.Meeting && x.Duration == 2 && !tasks.Contains(x)).ToList();
            tasks.AddRange(twoHoursMeetings.Take(rand.Next(1, 2)));

            if (tasks.Count == 9)
                return tasks;

            var meal = GameTasks.ListOfTasks.First(x => x.Type == TaskType.Meal && !tasks.Contains(x));
            tasks.Add(meal);

            if (tasks.Count == 9)
                return tasks;

            var leisureBReaks = GameTasks.ListOfTasks.Where(x => x.Type == TaskType.Leisure && !tasks.Contains(x)).ToList();
            tasks.AddRange(leisureBReaks.Take(rand.Next(1,2)));

            if (tasks.Count == 9)
                return tasks;

            while (tasks.Count != 9)
            {
                var validOneHourMeeting =
                    GameTasks.ListOfTasks.First(x => x.Type == TaskType.Meeting && x.Duration == 1 && !tasks.Contains(x));
                tasks.Add(validOneHourMeeting);
            }

            return tasks;
        }
    }

    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}