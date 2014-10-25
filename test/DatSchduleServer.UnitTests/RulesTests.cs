using System.Linq;
using DatScheduleServer.Model;
using NUnit.Framework;

namespace DatScheduleServer.Tests.UnitTests
{
    public class RulesTests
    {
        [Test]
        public void it_should_generate_a_new_day()
        {
            var game = new Game();

            Assert.That(game.CurrentDay, Is.Not.Null);
        }

        [Test]
        public void when_a_day_is_generated_it_should_have_tasks_matching_its_duration()
        {
            var game = new Game();

            Assert.That(game.CurrentDay.Tasks.Sum(x => x.Duration), Is.EqualTo(game.CurrentDay.Duration));
        }

        [Test]
        public void having_a_leisure_break_should_decrease_stress_by_10()
        {
            var game = new Game();

            const int stressLevel = 20;
            game.GameState.StressLevel = stressLevel;

            var task = new Task("Leisure Break", 1.0, TaskType.Leisure, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState);
            Assert.That(game.GameState.StressLevel, Is.EqualTo(stressLevel + GameRulesParameters.ImpactOfLeisureOnStress));
        }

        [Test]
        public void having_a_sleep_should_increase_fatigue()
        {
            var game = new Game();

            const int level = 20;

            game.GameState.TirednessLevel = level;

            var task = new Task("Sleep", 7.0, TaskType.Sleep, "");
            
            GameRulesEnforcer.ApplyRule(task, game.GameState);

            Assert.That(game.GameState.TirednessLevel, Is.EqualTo(level + GameRulesParameters.ImpactOfSleepOnTiredness));
        }

        [Test]
        public void having_a_meal_should_increase_hunger()
        {
            var game = new Game();

            const int level = 50;

            game.GameState.HungerLevel = level;

            var task = new Task("Meal", 1.0, TaskType.Meal, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState);

            Assert.That(game.GameState.HungerLevel, Is.EqualTo(level + GameRulesParameters.ImpactOfMealOnHunger));
        }

        [Test]
        public void GameWhenInitiasedWithoneTaskMustHaveColorCodeAssociated()
        {
            var game = new Game();

            Assert.That(game.CurrentDay.Tasks.FirstOrDefault().ColorCode, Is.Not.Empty);
        }
    }
}
