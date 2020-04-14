using System.Collections.Generic;

namespace Yatzy
{
    public class Player
    {
        private List<Dice> _rolledDices = new List<Dice>();
        public List<Dice> RollDice()
        {
            for (int i = 0; i < NumOfDicePerHand; i++)
            {
                _rolledDices.Add(new Dice());
            }

            return _rolledDices;
        }

        private const int NumOfDicePerHand = 5;
    }
}