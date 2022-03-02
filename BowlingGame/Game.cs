using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class Game
    {
        private readonly List<Frame> Frames = new();

        public Game()
        {
            for (int i = 0; i < 10; i++)
            {
                Frames.Add(new Frame(id: i + 1));
            }
        }

        public void Roll(int pinCount)
        {
            var currentFrame = RecordRoll(pinCount);
            RecoredBonus(pinCount, currentFrame);
        }

        private void RecoredBonus(int pinCount, Frame currentFrame)
        {
            var bonusFrames = Frames.FindAll(frame => frame.Id != currentFrame?.Id && frame.BonusAvailable());
            foreach (var frame in bonusFrames)
            {
                frame.Roll(pinCount);
            }
        }

        private Frame RecordRoll(int pinCount)
        {
            var currentFrame = Frames.Find(frame => !frame.RollsComplete());
            currentFrame?.Roll(pinCount);
            return currentFrame;
        }

        public int Score()
        {
            return Frames.Sum(f => f.Score());
        }
    }
}