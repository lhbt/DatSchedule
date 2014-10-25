using System.Collections.Generic;
using System.Linq;
using DatScheduleServer.Model;
using NUnit.Framework;

namespace DatScheduleServer.Tests.UnitTests
{
    public class RulesTests
    {
        [Test]
        public void it_should_generate_tasks_for_a_day()
        {
            var game = new Game();
            game.Initialise();

            var totalDurationOfTasks = game.Tasks.Sum(x => x.Duration);

            Assert.That(totalDurationOfTasks, Is.EqualTo(game.DayDuration));
        }

        [Test]
        public void having_a_leisure_break_should_decrease_stress_by_10()
        {
            var game = new Game();
            game.Initialise();

            const int stressLevel = 20;
            game.GameState.StressLevel = stressLevel;

            var task = new Task("Leisure Break", 1.0, TaskType.Leisure, "");


            new GameRules().ApplyRule(task, game.GameState);

            Assert.That(game.GameState.StressLevel, Is.EqualTo(stressLevel - GameRulesParameters.ImpactOfLeisureOnStress));
        }

        [Test]
        public void having_a_sleep_should_decrease_tiredness_by_60()
        {
            var game = new Game();
            game.Initialise();

            const int level = 90;

            game.GameState.TirednessLevel = level;

            var task = new Task("Sleep", 7.0, TaskType.Sleep, "");

            new GameRules().ApplyRule(task, game.GameState);

            Assert.That(game.GameState.TirednessLevel, Is.EqualTo(level - GameRulesParameters.ImpactOfSleepOnTiredness));
        }

        [Test]
        public void having_a_meal_should_decrease_hunger_by_30()
        {
            var game = new Game();
            game.Initialise();

            const int level = 50;

            game.GameState.HungerLevel = level;

            var task = new Task("Meal", 1.0, TaskType.Meal, "");

            new GameRules().ApplyRule(task, game.GameState);

            Assert.That(game.GameState.HungerLevel, Is.EqualTo(level - GameRulesParameters.ImpactOfMealOnHunger));
        }

        [Test]
        public void GameWhenInitiasedWithoneTaskMustHaveColorCodeAssociated()
        {
            var game = new Game();
            game.Initialise();

            const int level = 50;

            game.GameState.HungerLevel = level;



            Assert.That(game.Tasks.FirstOrDefault().ColorCode, Is.Not.Empty);
        }
    }
}
