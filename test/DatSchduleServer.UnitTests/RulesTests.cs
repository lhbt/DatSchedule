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
        public void it_should_weight_the_impact_on_levels_based_on_duration()
        {
            var game = new Game();

            const int duration = 2;
            var task = new Task("Leisure Break", duration, TaskType.Leisure, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);
            Assert.That(game.GameState.StressLevel, Is.EqualTo(game.GameState.StressLevel - GameRulesParameters.ImpactOfMeetingOnStress * duration));
        }

        [Test]
        public void having_a_leisure_break_should_increase_stress()
        {
            var game = new Game();

            const int stressLevel = 20;
            game.GameState.StressLevel = stressLevel;

            var task = new Task("Leisure Break", 1, TaskType.Leisure, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);
            Assert.That(game.GameState.StressLevel, Is.EqualTo(stressLevel + GameRulesParameters.ImpactOfLeisureOnStress));
        }

        [Test]
        public void having_a_sleep_should_increase_fatigue()
        {
            var game = new Game();

            const int level = 20;

            game.GameState.FatigueLevel = level;

            var task = new Task("Sleep", 7, TaskType.Sleep, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);

            Assert.That(game.GameState.FatigueLevel, Is.EqualTo(level + GameRulesParameters.ImpactOfSleepOnFatigue));
        }

        [Test]
        public void having_a_meal_should_increase_hunger()
        {
            var game = new Game();

            const int level = 50;

            game.GameState.HungerLevel = level;

            var task = new Task("Meal", 1, TaskType.Meal, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);

            Assert.That(game.GameState.HungerLevel, Is.EqualTo(level + GameRulesParameters.ImpactOfMealOnHunger));
        }

        [Test]
        public void it_should_record_the_duration_of_tasks_that_happened_in_a_day()
        { 
            var game = new Game();

            const int duration = 2;
            var task = new Task("Meal", duration, TaskType.Meal, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);

            Assert.That(game.CurrentDay.TimeSpent, Is.EqualTo(duration));

        }

        [Test]
        public void it_should_change_day_when_the_spent_duration_equals_the_total_day_duration()
        {
            var game = new Game();

            const int duration = 2;
            game.CurrentDay.Duration = duration;
            var task = new Task("Meal", duration, TaskType.Meal, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);

            Assert.That(game.GameState.DayIsOver, Is.True);
            Assert.That(game.CurrentDay.TimeSpent, Is.EqualTo(0));
        }

        [Test]
        public void GameWhenInitiasedWithoneTaskMustHaveColorCodeAssociated()
        {
            var game = new Game();

            Assert.That(game.CurrentDay.Tasks.FirstOrDefault().ColorCode, Is.Not.Empty);
        }
    }
}
