using System;
using System.Collections.Generic;
using System.Linq;

namespace DatScheduleServer.Model
{
    public static class RandomTaskGenerator
    {
        public static List<Task> GetUniqueSet(List<Task> listOfTasks, List<Task> leftOverTasks)
        {
            var random = new Random();
            List<Task> randomTaskList = leftOverTasks.Where(task => !task.Scheduled).ToList();

            while (GetUniquetasks(randomTaskList).Count != 9)
            {
                var index = random.Next(listOfTasks.Count());
                randomTaskList.Add(listOfTasks[index]);
            }

            return randomTaskList.Distinct().ToList();
        }

        private static List<Task> GetUniquetasks(IEnumerable<Task> randomTaskList)
        {
            return randomTaskList.Distinct().ToList();
        }
    }
}