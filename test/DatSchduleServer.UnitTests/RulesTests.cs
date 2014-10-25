using System.Collections.Generic;
using System.Linq;
using DatScheduleServer.Model;
using NUnit.Framework;

namespace DatScheduleServer.Tests.UnitTests
{
    public class RulesTests
    {
        [Test]
        public void it_should_generate_8_hours_of_tasks_for_a_day()
        {
            var game = new Game();
            game.Initialise();

            var totalDurationOfTasks = game.Tasks.Sum(x => x.Duration);

            Assert.That(totalDurationOfTasks, Is.EqualTo(8));
        }

        [Test]
        public void having_a_leisure_break_should_decrease_stress_by_10()
        {
            var game = new Game();
            game.Initialise();

            game.StressLevel = 20;

            var tasks = new List<Task>
            {
                new Task("Leisure Break", 1.0, TaskType.Leisure)
            };

            game.ProcessTasks(tasks);

            Assert.That(game.StressLevel, Is.EqualTo(10));
        }

        [Test]
        public void having_a_sleep_should_decrease_tiredness_by_60()
        {
            var game = new Game();
            game.Initialise();

            game.TirednessLevel = 90;

            var tasks = new List<Task>
            {
                new Task("Sleep", 7.0, TaskType.Sleep)
            };

            game.ProcessTasks(tasks);

            Assert.That(game.TirednessLevel, Is.EqualTo(30));
        }
    }
}
