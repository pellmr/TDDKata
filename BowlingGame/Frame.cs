using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class Frame
    {
        public int Id { get; }
        int? Roll1;
        int? Roll2;
        int? Bonus1;
        int? Bonus2;
        public Frame(int id)
        {
            Id = id;
        }

        internal bool RollsComplete()
        {
            return Roll2 != null;
        }

        internal void Roll(int pinCount)
        {
            if (Roll1 == null)
            {
                ProcessRoll1(pinCount);
            }
            else if (Roll2 == null)
            {
                ProcessRoll2(pinCount);
            }
            else if (Bonus1 == null)
            {
                Bonus1 = pinCount;
            }
            else if (Bonus2 == null)
            {
                Bonus2 = pinCount;
            }
        }

        private void ProcessRoll2(int pinCount)
        {
            Roll2 = pinCount;
            if (!IsSpare())
            {
                Bonus1 = 0;
                Bonus2 = 0;
            }
            else
            {
                Bonus2 = 0;
            }
        }

        private void ProcessRoll1(int pinCount)
        {
            Roll1 = pinCount;
            if (IsStrike())
                Roll2 = 0;
        }

        internal bool IsStrike()
        {
            return Roll1 == 10;
        }

        internal bool IsSpare()
        {
            return Roll1 != 10 && Roll1 + Roll2 == 10;
        }

        internal bool BonusAvailable()
        {
            return RollsComplete() && !FrameComplete();
        }

        internal int Score()
        {
            return (Roll1 ?? 0) + (Roll2 ?? 0) + (Bonus1 ?? 0) + (Bonus2 ?? 0);
        }

        internal bool FrameComplete()
        {
            return RollsComplete() && Bonus1 != null && Bonus2 != null;
        }
    }
}