using System;
using System.Collections.Generic;
using System.Linq;

namespace DatScheduleServer.Model
{
    public static class RandomTaskGenerator
    {
        public static List<Task> GetUniqueSet(List<Task> set)
        {
            var random = new Random();
            var randomTaskList = new List<Task>();

            while (GetUniquetasks(randomTaskList).Count != 9)
            {
                var index = random.Next(set.Count());
                randomTaskList.Add(set[index]);
            }

            return randomTaskList.Distinct().ToList();
        }

        private static List<Task> GetUniquetasks(IEnumerable<Task> randomTaskList)
        {
            return randomTaskList.Distinct().ToList();
        }
    }
}