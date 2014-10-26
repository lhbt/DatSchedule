using DatScheduleServer.Model;
using NUnit.Framework;

namespace DatScheduleServer.Tests.UnitTests
{
    public class GameScoreTests
    {
        [Test]
        public void WhenGameIsInitiatedTheTotalScoreWouldBeZero()
        {
            var game = new Game();
            Assert.That(game.TotalScore,Is.EqualTo(0));
        }

        [Test]
        public void WhenTaskIsAddedToTheTimelineThenScoreChanges()
        {
            var game = new Game();
            GameRulesEnforcer.ApplyRule(new Task("",0,TaskType.Leisure, "",false),game );
            Assert.That(game.TotalScore,Is.GreaterThan(0));
        }
    }
}