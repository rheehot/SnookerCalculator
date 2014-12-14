﻿using NUnit.Framework;
using SnookerCalculatorLib;

namespace SnookerCalculatorLibTests
{
    [TestFixture]
    class ToLeaveTheOtherPlayerNeedingASnookerTests
    {
        [Test]
        public void Player1WinningAndNeeds4RedsAnd4BlacksToLeaveSnookers()
        {
            const int player1Score = (1 + 7) * 6;
            const int player2Score = (1 + 7) * 2;
            const int numRedsRemaining = 15 - 6 - 2;
            var actual = SnookerCalculator.Analyse(player1Score, player2Score, numRedsRemaining);
            Assert.That(actual.AnalysisResultType, Is.EqualTo(AnalysisResultType.Player1Winning));
            Assert.That(actual.HowToAchieveFrameBall, Is.EqualTo(new[] {1, 7, 1, 7, 1, 7, 1, 7}));
        }

        [Test]
        public void Player2WinningAndNeeds4RedsAnd4BlacksToLeaveSnookers()
        {
            const int player1Score = (1 + 7) * 2;
            const int player2Score = (1 + 7) * 6;
            const int numRedsRemaining = 15 - 2 - 6;
            var actual = SnookerCalculator.Analyse(player1Score, player2Score, numRedsRemaining);
            Assert.That(actual.AnalysisResultType, Is.EqualTo(AnalysisResultType.Player2Winning));
            Assert.That(actual.HowToAchieveFrameBall, Is.EqualTo(new[] { 1, 7, 1, 7, 1, 7, 1, 7 }));
        }
    }
}
