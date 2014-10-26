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
        public void WhenAnyTaskIsAddedToTheTimelineThenUpdateScorebyTenPoints()
        {
            var game = new Game();
            ScoreRules.Apply(new Task("", 0, TaskType.Leisure, "", false), game);
            Assert.That(game.TotalScore,Is.EqualTo(10));
        }

        [Test]
        public void WhenAMeetingIsAddedToTheTimelineWithAnHourLongThenUpdateScorebyThirtyPoints()
        {
            var game = new Game();
            ScoreRules.Apply(new Task("", 0, TaskType.Meeting, "", false), game);
            Assert.That(game.TotalScore, Is.EqualTo(30));
        }

        [Test]
        public void WhenAMeetingIsAddedToTheTimelineWithTwoHourLongThenUpdateScorebyFortyPoints()
        {
            var game = new Game();
            ScoreRules.Apply(new Task("", 2, TaskType.Meeting, "", false), game);
            Assert.That(game.TotalScore, Is.EqualTo(40));
        }

        [Test]
        public void WhenAMeetingIsAddedToTheTimelineWithMoreThanHourLongThenUpdateScorebyFiftyPoints()
        {
            var game = new Game();
            ScoreRules.Apply(new Task("", 3, TaskType.Meeting, "", false), game);
            Assert.That(game.TotalScore, Is.EqualTo(50));
        }

        [Test]
        public void WhenSleepIsAddedToTheTimelineWithAnHourLongThenUpdateScorebyTwentyPoints()
        {
            var game = new Game();
            ScoreRules.Apply(new Task("", 1, TaskType.Sleep, "", false), game);
            Assert.That(game.TotalScore, Is.EqualTo(20));
        }
    }
}