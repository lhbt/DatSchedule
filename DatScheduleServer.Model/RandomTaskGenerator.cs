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

            while (GetUniquetasks(randomTaskList).Count != 9 && !ListIsBalanced(randomTaskList))
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

        private static bool ListIsBalanced(IEnumerable<Task> randomTaskList)
        {
            var taskList = randomTaskList as Task[] ?? randomTaskList.ToArray();

            var threeHrsLongMeetings = GetMeetingsOfDuration(taskList, 3).ToList();
            var betweenOneAndTwo3HrsMeetings = threeHrsLongMeetings.Count() <= 1 && threeHrsLongMeetings.Count() >= 2;

            var twoHrsLongMeetings = GetMeetingsOfDuration(taskList, 2).ToList();
            var betweenOneAndTwoHrsLongMeetings = twoHrsLongMeetings.Count() <= 1 && twoHrsLongMeetings.Count() >= 2;

            var oneMeal = taskList.Count(x => x.Type == TaskType.Meal) == 1;

            var leisureBreaks = taskList.Count(x => x.Type == TaskType.Leisure);
            var betweenOneAndTwoLeisureBReaks = leisureBreaks <= 1 && leisureBreaks >= 3;

            return betweenOneAndTwo3HrsMeetings && betweenOneAndTwoHrsLongMeetings && oneMeal &&
                   betweenOneAndTwoLeisureBReaks;
        }

        private static IEnumerable<Task> GetMeetingsOfDuration(IEnumerable<Task> randomTaskList, int duration)
        {
            return randomTaskList.Where(x => x.Type == TaskType.Meeting && x.Duration == duration);
        }
    }
}