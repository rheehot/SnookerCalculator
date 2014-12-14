﻿using NUnit.Framework;
using SnookerCalculatorLib;

namespace SnookerCalculatorLibTests
{
    [TestFixture]
    class SnookerCalculatorTests
    {
        [Test]
        public void Player1WinningAndNeeds4RedsAnd4BlacksToLeaveSnookers()
        {
            const int player1Score = (1 + 7) * 6;
            const int player2Score = (1 + 7) * 2;
            const int numRedsRemaining = 15 - 6 - 2;
            var actual = SnookerCalculator.Analyse(player1Score, player2Score, numRedsRemaining);
            Assert.That(actual.AnalysisResultType, Is.EqualTo(AnalysisResultType.Player1Winning));
            Assert.That(actual.FrameBallDetails.FrameBalls, Is.EqualTo(new[] {1, 7, 1, 7, 1, 7, 1, 7}));
            Assert.That(actual.FrameBallDetails.Score, Is.EqualTo(80));
            Assert.That(actual.FrameBallDetails.PointsAhead, Is.EqualTo(64));
            Assert.That(actual.FrameBallDetails.PointsRemaining, Is.EqualTo(51));
        }

        [Test]
        public void Player2WinningAndNeeds4RedsAnd4BlacksToLeaveSnookers()
        {
            const int player1Score = (1 + 7) * 2;
            const int player2Score = (1 + 7) * 6;
            const int numRedsRemaining = 15 - 2 - 6;
            var actual = SnookerCalculator.Analyse(player1Score, player2Score, numRedsRemaining);
            Assert.That(actual.AnalysisResultType, Is.EqualTo(AnalysisResultType.Player2Winning));
            Assert.That(actual.FrameBallDetails.FrameBalls, Is.EqualTo(new[] { 1, 7, 1, 7, 1, 7, 1, 7 }));
            Assert.That(actual.FrameBallDetails.Score, Is.EqualTo(80));
            Assert.That(actual.FrameBallDetails.PointsAhead, Is.EqualTo(64));
            Assert.That(actual.FrameBallDetails.PointsRemaining, Is.EqualTo(51));
        }

        [Test]
        public void DrawNeeds6RedsAnd6BlacksToLeaveSnookers()
        {
            const int player1Score = (1 + 7) * 4;
            const int player2Score = (1 + 7) * 4;
            const int numRedsRemaining = 15 - 4 - 4;
            var actual = SnookerCalculator.Analyse(player1Score, player2Score, numRedsRemaining);
            Assert.That(actual.AnalysisResultType, Is.EqualTo(AnalysisResultType.Draw));
            Assert.That(actual.FrameBallDetails.FrameBalls, Is.EqualTo(new[] {1, 7, 1, 7, 1, 7, 1, 7, 1, 7, 1, 7}));
            Assert.That(actual.FrameBallDetails.Score, Is.EqualTo(80));
            Assert.That(actual.FrameBallDetails.PointsAhead, Is.EqualTo(48));
            Assert.That(actual.FrameBallDetails.PointsRemaining, Is.EqualTo(35));
        }

        [Test]
        public void Player1OnlyNeedsBlueAndPink()
        {
            const int player1Score = 50;
            const int player2Score = 45;
            const int numRedsRemaining = 0;
            const int lowestAvailableColour = 5;
            var actual = SnookerCalculator.Analyse(player1Score, player2Score, numRedsRemaining, lowestAvailableColour);
            Assert.That(actual.AnalysisResultType, Is.EqualTo(AnalysisResultType.Player1Winning));
            Assert.That(actual.FrameBallDetails.FrameBalls, Is.EqualTo(new[] {5, 6}));
            Assert.That(actual.FrameBallDetails.Score, Is.EqualTo(61));
            Assert.That(actual.FrameBallDetails.PointsAhead, Is.EqualTo(16));
            Assert.That(actual.FrameBallDetails.PointsRemaining, Is.EqualTo(7));
        }

        [Test]
        public void Player1AchievedFrameBallAgesAgo()
        {
            const int player1Score = (1 + 7) * 15;
            const int player2Score = 0;
            const int numRedsRemaining = 0;
            var actual = SnookerCalculator.Analyse(player1Score, player2Score, numRedsRemaining);
            Assert.That(actual.AnalysisResultType, Is.EqualTo(AnalysisResultType.Player1Winning));
            Assert.That(actual.FrameBallDetails.FrameBalls, Is.Empty);
            Assert.That(actual.FrameBallDetails.Score, Is.EqualTo(120));
            Assert.That(actual.FrameBallDetails.PointsAhead, Is.EqualTo(120));
            Assert.That(actual.FrameBallDetails.PointsRemaining, Is.EqualTo(27));
        }
    }
}