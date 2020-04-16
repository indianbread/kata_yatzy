using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Yatzy
{
    public class Player
    {
        private List<Dice> _rolledDices = new List<Dice>();
        public List<Dice> RollDice()
        {
            for (int i = 0; i < _numOfDicePerHand; i++)
            {
                _rolledDices.Add(new Dice());
            }

            return _rolledDices;
        }

        private List<int> myNumbers => _rolledDices.Select(dice => dice.GetValue()).ToList();

        //make a function to generate a sorted list of scores and categories


        private const int _numOfDicePerHand = 5;
    }
}