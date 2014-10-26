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
            GameRulesEnforcer.ApplyRule(new Task("Team Meeting", 2, TaskType.Meeting, "#33CCFF"),game);
            GameRulesEnforcer.ApplyRule(new Task("Big Executive Meeting", 3, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule(new Task("Retrospective", 2, TaskType.Meeting, "#33CCFF"), game);
            GameRulesEnforcer.ApplyRule( new Task("Leisure", 1, TaskType.Leisure, "#FFFF33"),game);
            Assert.That(game.CurrentDay.Tasks.Any(x => !x.Scheduled));
        }
    }
}