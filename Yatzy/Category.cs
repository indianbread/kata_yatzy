using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;

namespace Yatzy
{
    public class Category
    {
        private int[] _diceNumbers;

        private SortedList<int, int> _diceNumbersWithCount = new SortedList<int, int>();

        public Category(int[] diceNumbers) 
        {
            _diceNumbers = diceNumbers;
            _diceNumbersWithCount = GetDiceNumbersWithCount();
        }
        
        //can also take list of dice as param
        // public Category(List<Dice> dice)
        // {
        //     _diceNumbers = dice.Select(die => die.GetValue()).ToList();
        // }
        
        public int Chance()
        {
            int sum = _diceNumbers.Aggregate((result, number) => result + number);
            return sum;
        }

        public int Yatzy()
        {
            bool isYatzy = true;
        
            for (int i = 0; i < (_diceNumbers.Length - 1); i++)
            {
                if (_diceNumbers[i] == _diceNumbers[i + 1]) continue;
                isYatzy = false;
                break;
            }

            int total = isYatzy ? 50 : 0;
            return total;
        }
        
        private int GetNumbersPoints(int categoryNumber)
        {
            bool isNumberPresent = _diceNumbers.Any(number => number == categoryNumber);

            return isNumberPresent ? _diceNumbersWithCount[categoryNumber] * categoryNumber : 0;
        }

        public int Ones()
        {
            return GetNumbersPoints(1);
        }

        public int Twos()
        {
            return GetNumbersPoints(2);
        }

        public int Threes()
        {
            return GetNumbersPoints(3);
        }

        public int Fours()
        {
            return GetNumbersPoints(4);
        }

        public int Fives()
        {
            return GetNumbersPoints(5);
        }

        public int Sixes()
        {
            return GetNumbersPoints(6);
        }
     
        public int Pair()
        {
            var possiblePairs = GetNumbersWithMultipleOccurence(2);
            return possiblePairs.Any() ?  possiblePairs.Max() * 2 : 0;
        }

        public int TwoPair()
        {
            var possiblePairs = GetNumbersWithMultipleOccurence(2);
            return (possiblePairs.Count() == 2) ? (possiblePairs.Aggregate((result, value) => result + value) * 2) : 0;
        }
        
        public int ThreeOfAKind()
        {
            return GetMultipleOfAKindScore(3);

        }

        public int FourOfAKind()
        {

            return GetMultipleOfAKindScore(4);

        }
        
        public int SmallStraight()
        {
            int startingNumber = 1;
            int totalScore = GetStraightTotalScore(startingNumber);
            return totalScore;
        }

        public int LargeStraight()
        {
            int startingNumber = 2;
            int totalScore = GetStraightTotalScore(startingNumber);
            return totalScore;
        }

        public int FullHouse()
        {
            var threeOfAKind = _diceNumbersWithCount.FirstOrDefault(diceCount => diceCount.Value == 3);
            var pair = _diceNumbersWithCount.FirstOrDefault(diceCount => diceCount.Value == 2);
            return (threeOfAKind.Key > 0) && (pair.Key > 0) ? (threeOfAKind.Key * 3) + (pair.Key * 2) : 0;
        }
        
        private SortedList<int, int> GetDiceNumbersWithCount()
        {
            var numbers = _diceNumbers.GroupBy(number => number);
            foreach (var number in numbers)
            {
                _diceNumbersWithCount.Add(number.Key, number.Count());
            }

            return _diceNumbersWithCount;
        }

        private IEnumerable<int> GetNumbersWithMultipleOccurence(int multiple)
        {
            var diceCounts = _diceNumbersWithCount.Where(diceCount => diceCount.Value >= multiple);
            var diceNumbers = diceCounts.Select(diceCount => diceCount.Key);
            return diceNumbers;
        }

        private int GetMultipleOfAKindScore(int multiple)
        {
            var multipleOfAKindNumberList = GetNumbersWithMultipleOccurence(multiple);
            var multipleOfAKindNumber = multipleOfAKindNumberList.Any() ? multipleOfAKindNumberList.First() : 0;
            int total = multipleOfAKindNumber * multiple;
            return total;
        }
        
        private int GetStraightTotalScore(int startingNumber)
        {
            int totalScore = 0;
            if (startingNumber != _diceNumbers.Min())
            {
                return totalScore;
            }
            totalScore = startingNumber;
            for (int i = 1; i < _diceNumbers.Length; i++)
            {
                if (_diceNumbers[i] == (_diceNumbers[i - 1] + 1))
                {

                    totalScore += _diceNumbers[i];
                }
                else
                {
                    totalScore = 0;
                    break;
                }
            }
            return totalScore;
        }

    }

}