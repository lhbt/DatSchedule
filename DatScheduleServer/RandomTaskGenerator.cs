using System;
using System.Collections.Generic;
using System.Linq;
using DatScheduleServer.Model;

namespace DatScheduleServer
{
    public static class RandomTaskGenerator
    {
        public static List<Task> GetUniquieSet(List<Task> set)
        {
            var random = new Random();
            var randomTaskList = new List<Task>();
            while (GetUniquetasks(randomTaskList).Count != 9)
            {
                int index = random.Next(set.Count());
                randomTaskList.Add(set[index]);
            }


            return randomTaskList.Distinct().ToList();
        }

        private static List<Task> GetUniquetasks(List<Task> randomTaskList)
        {
            return randomTaskList.Distinct().ToList();
        }
    }
}