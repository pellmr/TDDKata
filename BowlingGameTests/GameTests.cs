using System;
using Xunit;
using BowlingGame;
using System.Collections.Generic;

namespace BowlingGameTests
{
    public class GameTests
    {
        [Fact]
        public void WhenAllGutterBallsAreThrown_GameScoreShouldBeZero()
        {
            //arrange
            Game Game = new();

            //act
            for (var i = 0; i < 20; i++)
            {
                Game.Roll(0);
            }
            var finalScore = Game.Score();

            //assert
            Assert.Equal(0, finalScore);
        }

        [Fact]
        public void WhenOnePinPerRollIsKnockedDown_GameScoreShouldBeTwenty()
        {
            //arrange
            Game Game = new();

            //act
            for (var i = 0; i < 20; i++)
            {
                Game.Roll(1);
            }
            var finalScore = Game.Score();

            //assert
            Assert.Equal(20, finalScore);
        }
    }
}
