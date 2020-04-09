using System;

namespace Yatzy
{
    public class Dice
    {

        public Dice(int value)
        {
            _value = value;
        }

        public Dice()
        {
            Random random = new Random();
            _value = random.Next(MinDiceValue, MaxDiceValue);
        }
        
        
        
        private int _value { get; }
        public int GetValue()
        {
            return _value;
        }
        
        private const int MinDiceValue = 1;
        private const int MaxDiceValue = 6;
    }
}