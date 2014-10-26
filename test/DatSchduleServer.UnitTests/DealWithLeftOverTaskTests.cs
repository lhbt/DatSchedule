﻿using System.Collections.Generic;
using System.Linq;
using DatScheduleServer.Model;
using NUnit.Framework;

namespace DatScheduleServer.Tests.UnitTests
{
    public class DealWithLeftOverTaskTests
    {
        [Test]
        public void GivenIHaveFilledADayAndATaskLeftOverMarkThemAsNotScheduled()
        {
            var game = new Game();
            GameRulesEnforcer.ApplyRule(new Task("Team Meeting", 2, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule(new Task("Big Executive Meeting", 3, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule(new Task("Retrospective", 2, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule(new Task("Leisure", 1, TaskType.Leisure, "#FFFF33"), game);
            Assert.That(game.CurrentDay.Tasks.Any(x => !x.Scheduled));
        }
        [Ignore]
        [Test]
        public void GivenIHaveFilledADayThenLeftOverTasksAreAppendedInNextDay()
        {
            var game = new Game();
            game.CurrentDay.Tasks = new List<Task>
            {
                new Task("Team Meeting", 2, TaskType.Meeting, "#33CCFF"),
                new Task("Interview", 1, TaskType.Meeting, "#33CCFF"),
                new Task("Big Executive Meeting", 3, TaskType.Meeting, "#33CCFF"),
                new Task("Retrospective", 2, TaskType.Meeting, "#33CCFF"),
                new Task("Conf. call", 1, TaskType.Meeting, "#33CCFF"),
                new Task("PDU", 1, TaskType.Meeting, "#33CCFF"),
                new Task("Code Kata", 1, TaskType.Meeting, "#33CCFF"),
                new Task("Git Brown Bag", 1, TaskType.Meeting, "#33CCFF"),
                new Task("Budget catchup", 2, TaskType.Meeting, "#33CCFF")
            };
            GameRulesEnforcer.ApplyRule(new Task("Team Meeting", 2, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule(new Task("Big Executive Meeting", 3, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule(new Task("Retrospective", 2, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule(new Task("Interview", 1, TaskType.Meeting, "#33CCFF"), game);

            var leftOverTasks = game.CurrentDay.Tasks.Where(x => !x.Scheduled).ToList();

            var matchingTasksInNextDay = (from g in game.CurrentDay.Tasks
                                          from lt in leftOverTasks
                                          where g.Name == lt.Name
                                          select lt);
            Assert.That(matchingTasksInNextDay.Count(), Is.EqualTo(leftOverTasks.Count));
        }
    }
}