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
            ThrowRolls();

            //assert
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void WhenOnePinPerRollIsKnockedDown_GameScoreShouldBeTwenty()
        {
            //arrange

            //act
            ThrowRolls(scorePerRoll: 1);

            //assert
            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void WhenASpareIsThrownInFirstFrameAndTheFirstRollOfNextFrameIs3RemainingRollsAreGutters_GameScoreShouldBe16()
        {
            //arrange

            //act
            game.Roll(0);
            game.Roll(10);
            game.Roll(3);
            ThrowRolls(17);

            //assert
            Assert.Equal(16, game.Score());
        }

        private void ThrowRolls(int numberOfRolls = 20, int scorePerRoll = 0)
        {
            for (var i = 0; i < numberOfRolls; i++)
            {
                game.Roll(scorePerRoll);
            }
        }
    }
}
