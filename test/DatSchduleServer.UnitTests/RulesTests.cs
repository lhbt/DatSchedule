﻿using System.Linq;
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

            var task = new Task("Leisure Break", 1, TaskType.Leisure, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);
            Assert.That(game.GameState.StressLevel, Is.EqualTo(stressLevel + GameRulesParameters.ImpactOfLeisureOnStress));
        }

        [Test]
        public void having_a_sleep_should_increase_fatigue()
        {
            var game = new Game();

            const int level = 20;

            game.GameState.TirednessLevel = level;

            var task = new Task("Sleep", 7, TaskType.Sleep, "");

            GameRulesEnforcer.ApplyRule(task, game.GameState, game.CurrentDay);

            Assert.That(game.GameState.TirednessLevel, Is.EqualTo(level + GameRulesParameters.ImpactOfSleepOnTiredness));
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
