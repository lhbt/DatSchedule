using System.Collections.Generic;
using System.Linq;
using DatScheduleServer.Model;
using NUnit.Framework;

namespace DatScheduleServer.Tests.UnitTests
{
    public class GenerateRandomUniqieTasksTests
    {

        [Test]
        public void GivenSetOftasksMustReturnInRandomOrder()
        {
            var duplicateTasks = new List<Task>
            {
                new Task("Dup",10,TaskType.Meeting,""),
                new Task("Dup",10,TaskType.Meeting,""),
                new Task("Dup1",10,TaskType.Meeting,""),
                new Task("Dup2",10,TaskType.Meeting,""),
                new Task("Dup3",10,TaskType.Meeting,""),
                new Task("Dup4",10,TaskType.Meeting,""),
                new Task("Dup5",10,TaskType.Meeting,""),
                new Task("Dup6",10,TaskType.Meeting,""),
                new Task("Dup7",10,TaskType.Meeting,""),
                new Task("Dup8",10,TaskType.Meeting,""),
                new Task("Dup9",10,TaskType.Meeting,""),
                new Task("Dup19",10,TaskType.Meeting,"")
            };
            List<Task> setOfTasks = RandomTaskGenerator.GetUniquieSet(duplicateTasks);
            var duplicates = setOfTasks.GroupBy(x => x.Name).Where(g => g.Count() > 1).Select(x => x.Key).ToList();
            Assert.That(setOfTasks, Is.Not.Null);
            Assert.That(setOfTasks.Any());
            Assert.That(setOfTasks.Count(), Is.EqualTo(9));
            Assert.That(duplicates.Any(), Is.False);
        }
    }
}