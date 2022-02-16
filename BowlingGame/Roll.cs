namespace BowlingGame
{
    public class Roll
    {
        public Roll(int pinCount)
        {
            PinsKnockedDown = pinCount;
        }

        public int PinsKnockedDown { get; set; }
    }
}