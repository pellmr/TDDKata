using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class Game
    {
        private readonly List<Frame> Frames = new();

        private int TotalScore = 0;

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
            TotalScore += pinCount;
            // var currentFrame = Frames.First(frame => frame.IsComplete());
            // currentFrame.Score(pinCount);
        }

        public int Score()
        {
            return TotalScore;
        }
    }
}