using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Yatzy
{
    public class Category
    {
        private List<int> _diceNumbers;

        public Category(List<int> diceNumbers) 
        {
            _diceNumbers = diceNumbers;
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
            var countOfDice = _diceNumbers.FindAll(diceNumber => diceNumber == categoryNumber).Count;
            var result = countOfDice * categoryNumber;
            return result;
        }
        
  /*      public int Ones()
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
        */
        
        
        public int Pair()
        {
            return GetPairPoints(1);

        }

        public int TwoPair()
        {
            return GetPairPoints(2);

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
            int threeOfAKindPoints = ThreeOfAKind();
            if (threeOfAKindPoints == 0)
            {
                return totalScore;
            }

            int threeOfAKindNumber = GetNumbersWithMultipleOccurence(3).First();
            _diceNumbers.RemoveAll(number => number == threeOfAKindNumber);
            int pairPoints = Pair();
            if (pairPoints == 0)
            {
                return totalScore;
            }

            totalScore = threeOfAKindPoints + pairPoints;
            return totalScore;

        }


        
        private int GetPairPoints(int numberOfPairs)
        {
            var possiblePairs = GetNumbersWithMultipleOccurence(2);
            var targetPairExists = possiblePairs.Count >= numberOfPairs;
            int totalPoints = 0;
            if (targetPairExists)
            {
                totalPoints = numberOfPairs == 1 ? possiblePairs.Max() * 2 : CalculateTwoPairScore(possiblePairs);

            }
            return totalPoints;
        }

        private List<int> GetNumbersWithMultipleOccurence(int multiple)
        {
            var numbers = _diceNumbers.GroupBy(number => number)
                .Where(number => number.Count() >= multiple)
                .Select(numberGroup => numberGroup.Key)
                .ToList();
            return numbers;
        }

        private int CalculateTwoPairScore(List<int> numbers)
        {
            
            var total = numbers.Aggregate((result, number) => result + number) * 2;
            return total;
        }
        
        private int GetMultipleOfAKindScore(int multiple)
        {
            var multipleOfAKindNumberList = GetNumbersWithMultipleOccurence(multiple);
            var multipleOfAKindNumber = 0;
            if (multipleOfAKindNumberList.Any())
            {
                multipleOfAKindNumber = multipleOfAKindNumberList.First();
            }
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