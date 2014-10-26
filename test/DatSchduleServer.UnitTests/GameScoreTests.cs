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
    }
}