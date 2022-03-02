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
                Frames.Add(new Frame());
            }
        }

        public int Score()
        {
            return Frames.Sum(f => f.Score);
        }

        public void Roll(int pinCount)
        {
            var currentFrame = RecordRoll(pinCount);
            RecoredBonus(pinCount, currentFrame);
        }

        private void RecoredBonus(int pinCount, Frame currentFrame)
        {
            foreach (var frame in Frames.FindAll(frame => frame != currentFrame && frame.BonusAvailable()))
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
    }
}