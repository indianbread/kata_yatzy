using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Yatzy
{
    public class Player
    {
        private List<Dice> _rolledDices = new List<Dice>();
        private int[] _myNumbers => _rolledDices.Select(dice => dice.GetValue()).ToArray();
        public List<Dice> RollDice()
        {
            for (int i = 0; i < _numOfDicePerHand; i++)
            {
                _rolledDices.Add(new Dice());
            }

            return _rolledDices;
        }
        
        private const int _numOfDicePerHand = 5;
    }
}