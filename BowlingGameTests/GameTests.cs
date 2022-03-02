using System;
using Xunit;
using BowlingGame;
using System.Collections.Generic;

namespace BowlingGameTests
{
    public class GameTests
    {
        private readonly Game game;
        public GameTests()
        {
            game = new();
        }

        [Fact]
        public void WhenAllGutterBallsAreThrown_GameScoreShouldBeZero()
        {
            //arrange

            //act
            RollMany();

            //assert
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void WhenOnePinPerRollIsKnockedDown_GameScoreShouldBeTwenty()
        {
            //arrange

            //act
            RollMany(scorePerRoll: 1);

            //assert
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void WhenASpareIsThrown_GameScoreShouldScoreNextRollAsABonus()
        {
            //arrange

            //act
            RollSpare();
            game.Roll(3);
            RollMany(17);

            //assert
            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void WhenAStrikeIsThrownInFirst9Frames_GameScoreShouldScoreSubsequentTwoRollsAsABonus()
        {
            //arrange

            //act
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(17);

            //assert
            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void WhenAllStrikesAreThrown_GameScoreShouldBe300()
        {
            //arrange

            //act
            RollMany(numberOfRolls: 12, scorePerRoll: 10);

            //assert
            Assert.Equal(300, game.Score());
        }
        [Fact]
        public void WhenAllStrikesAreThrownExeptTheLastRollIsA9_GameScoreShouldBe299()
        {
            //arrange

            //act
            RollMany(numberOfRolls: 11, scorePerRoll: 10);
            game.Roll(9);

            //assert
            Assert.Equal(299, game.Score());
        }
        [Fact]
        public void WhenAllStrikesAreThrownExeptTheLastFrameIsASpareThenStrike_GameScoreShouldBe279()
        {
            //arrange

            //act
            RollMany(numberOfRolls: 9, scorePerRoll: 10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);

            //assert
            Assert.Equal(279, game.Score());
        }
        [Fact]
        public void WhenAll9SparesAndAStrikeAreThrow_GameScoreShouldBe191()
        {
            //arrange

            //act
            RollManySpares(firstRollCount: 9);
            game.Roll(10);

            //assert
            Assert.Equal(191, game.Score());
        }

        private void RollManySpares(int numberOfRolls = 10, int firstRollCount = 0)
        {
            for (int i = 0; i < numberOfRolls; i++)
            {
                RollSpare(firstRollCount: firstRollCount);
            }
        }

        private void RollMany(int numberOfRolls = 20, int scorePerRoll = 0)
        {
            for (var i = 0; i < numberOfRolls; i++)
            {
                game.Roll(scorePerRoll);
            }
        }

        private void RollSpare(int firstRollCount = 0)
        {
            game.Roll(firstRollCount);
            game.Roll(10 - firstRollCount);
        }
    }
}
