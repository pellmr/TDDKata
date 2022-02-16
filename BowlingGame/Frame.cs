using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class Frame
    {
        public Frame()
        {
        }

        public List<Roll> Rolls { get; set; } = new();

        internal void Score(int pinCount)
        {
            Rolls.Add(new Roll(pinCount));
        }
        public bool IsComplete()
        {
            return SumRolls() == 10 || Rolls.Count == 2;
        }

        public int SumRolls()
        {
            return Rolls.Sum(r => r.PinsKnockedDown);
        }
    }
}