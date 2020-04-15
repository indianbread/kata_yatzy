using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace Yatzy.Test
{
    public class CategoryShould
    {
        [Theory]
        [InlineData(14, 1, 1, 3, 3, 6)]
        [InlineData(21, 4, 5, 5, 6, 1)]
        public void ReturnSumOfAllDiceForChance(int expectedTotal, int dice1, int dice2, int dice3, int dice4, int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.Chance());
        }
        
        [Theory]
        [InlineData(50, 1, 1, 1, 1, 1)]
        public void Return50ForYatzy(int expectedTotal, int dice1, int dice2, int dice3, int dice4, int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.Yatzy());
        }
        
        [Theory]
        [InlineData(0, 1, 1, 1, 2, 1)]
        public void Return0IfNotYatzy(int expectedTotal, int dice1, int dice2, int dice3, int dice4, int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.Yatzy());
        }

        [Theory]
        [InlineData(2, 1, 1, 2, 4, 4)]
        public void ReturnSumOfDiceWithValue1ForOnes(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.GetNumbersPoints(1
            ));
        }
        
        [Theory]
        [InlineData(0, 3, 3, 3, 4, 5)]
        public void Return0IfNoDiceWith1ForOnes(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.GetNumbersPoints(1
            ));
        }
        
        [Theory]
        [InlineData(2, 1, 1, 2, 4, 4)]
        public void ReturnSumOfDiceWithValue2ForTwos(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.GetNumbersPoints(2));
        }
        
        [Theory]
        [InlineData(8, 1, 1, 2, 4, 4)]
        public void ReturnSumOfDiceWithValue4ForFours(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.GetNumbersPoints(4));
        }
        
        [Theory]
        [InlineData(0, 1, 1, 2, 4, 4)]
        public void Return0IfNotDiceWithValue6ForSixes(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.GetNumbersPoints(6));
        }

        [Theory]
        [InlineData(8, 3, 3, 3, 4, 4)]
        [InlineData(12, 1, 1, 6, 2, 6)]
        [InlineData(6, 3, 3, 3, 4, 1)]
        [InlineData(6, 3, 3, 3, 3, 1)]
        public void ReturnSumOfTwoHighestMatchingDiceForPair(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.Pair());
        }
        
        [Theory]
        [InlineData(0, 3, 1, 2, 5, 4)]

        public void Return0IfNoPairForPair(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.Pair());
        }
        
        [Theory]
        [InlineData(8, 1, 1, 2, 3, 3)]
        [InlineData(0, 1, 1, 2, 3, 4)]
        [InlineData(6, 1, 1, 2, 2, 2)]
        public void ReturnSumOfMatchingDiceForTwoPair(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.TwoPair());
        }
        
        [Theory]
        [InlineData(0, 1, 1, 3, 4, 2)]
        public void Return0IfNoTwoPairsOfMatchingDiceForTwoPair(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.TwoPair());
        }
        
        [Theory]
        [InlineData(9, 3, 3, 3, 4, 5)]
        [InlineData(9, 3, 3, 3, 3, 1)]
        public void ReturnSumOfMatchingDiceForThreeOfAKind(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.ThreeOfAKind());
        }
        
        [Theory]
        [InlineData(0, 3, 3, 4, 5, 6)]
        public void Return0WhenNoMatchingDiceForThreeOfAKind(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.ThreeOfAKind());
        }
        
        [Theory]
        [InlineData(8, 2, 2, 2, 2, 5)]
        [InlineData(8, 2, 2, 2, 2, 2)]
        public void ReturnSumOfMatchingDiceForFourOfAKind(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.FourOfAKind());
        }
        
        [Theory]
        [InlineData(0, 2, 2, 2, 5, 5)]
        public void Return0WhenNoMatchingDiceForFourOfAKind(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.FourOfAKind());
        }
        
        [Theory]
        [InlineData(15, 1, 2, 3, 4, 5)]
        public void ReturnSumOfAllDiceForSmallStraight(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.SmallStraight());
        }
        
        [Theory]
        [InlineData(0, 1, 1, 3, 4, 5)]
        [InlineData(0, 2, 3, 4, 5, 6)]
        public void Return0IfDiceDoesNotQualifyForSmallStraight(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.SmallStraight());
        }
        
        [Theory]
        [InlineData(20, 2, 3, 4, 5, 6)]
        public void ReturnSumOfAllDiceForLargeStraight(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.LargeStraight());
        }
        
        [Theory]
        [InlineData(0, 2, 3, 3, 4, 5)]
        [InlineData(0, 1, 2, 3, 4, 5)]
        public void Return0IfDiceDoesNotQualifyForLargeStraight(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.LargeStraight());
        }
        
        [Theory]
        [InlineData(8, 1, 1, 2, 2, 2)]
        public void ReturnSumOfAllDiceForFullHouse(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.FullHouse());
        }
        
        [Theory]
        [InlineData(0, 2, 2, 3, 3, 4)]
        [InlineData(0, 4, 4, 4, 4, 4)]
        public void Return0IfNotEligibleForFullHouse(int expectedTotal, int dice1, int dice2, int dice3, int dice4,
            int dice5)
        {
            List<int> diceNumbers = new List<int>() {dice1, dice2, dice3, dice4, dice5};
            Category category = new Category(diceNumbers);
            
            Assert.Equal(expectedTotal, category.FullHouse());
        }

    }
}