using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Yatzy
{
    public class Category
    {
        private List<int> _diceNumbers;

        private SortedList<int, int> _diceNumbersWithCount = new SortedList<int, int>();

        public Category(List<int> diceNumbers) 
        {
            _diceNumbers = diceNumbers;
            _diceNumbersWithCount = GetDiceNumbersWithCount();
        }
        
        //can also take list of dice as param
        public Category(List<Dice> dice)
        {
            _diceNumbers = dice.Select(die => die.GetValue()).ToList();
        }
        public int Chance()
        {
            int sum = _diceNumbers.Aggregate((result, number) => result + number);
            return sum;
        }

        public int Yatzy()
        {
            bool isYatzy = true;
        
            for (int i = 0; i < (_diceNumbers.Count - 1); i++)
            {
                if (_diceNumbers[i] == _diceNumbers[i + 1]) continue;
                isYatzy = false;
                break;
            }

            int total = isYatzy ? 50 : 0;
            return total;
        }
        
        public int GetNumbersPoints(int categoryNumber)
        {
            bool isNumberPresent = _diceNumbers.Any(number => number == categoryNumber);

            return isNumberPresent ? _diceNumbersWithCount[categoryNumber] * categoryNumber : 0;
        }
     
        public int Pair()
        {
            int totalScore = 0;
            var possiblePairs = GetNumbersWithMultipleOccurence(2);
            return possiblePairs.Any() ?  possiblePairs.Max() * 2 : 0;
        }

        public int TwoPair()
        {
            int totalScore = 0;
            var possiblePairs = GetNumbersWithMultipleOccurence(2);
            if (possiblePairs.Count() == 2)
            {
                totalScore = possiblePairs.Aggregate((result, value) => result + value) * 2;
            }

            return totalScore;

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
            int totalScore = 0;
            var threeOfAKind = _diceNumbersWithCount.FirstOrDefault(diceCount => diceCount.Value == 3);
            if (threeOfAKind.Key > 0)
            {
                var pair = _diceNumbersWithCount.FirstOrDefault(diceCount => diceCount.Value == 2);
                if (pair.Key > 0)
                {
                    totalScore = (threeOfAKind.Key * 3) + (pair.Key * 2);
                }
            }

            return totalScore;
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
            for (int i = 1; i < _diceNumbers.Count; i++)
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