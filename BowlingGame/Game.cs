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
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
            Frames.Add(new Frame());
        }

        public void Roll(int pinCount)
        {
            // var currentFrame = Frames.First(frame => frame.IsComplete());
            // currentFrame.Score(pinCount);
        }

        public int Score()
        {
            return 0;
        }
    }
}