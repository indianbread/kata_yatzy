using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using Yatzy;

namespace Yatzy.Test
{
    public class CategoryScoreShould
    {
        public CategoryScoreShould()
        {
            CategoryScore = new CategoryScore(_dices);
        }
        
        public CategoryScore CategoryScore;
        private static List<Dice> _dices = new List<Dice>()
        {
            {new Dice(1)},
            {new Dice(2)},
            {new Dice(1)},
            {new Dice(4)},
            {new Dice(6)}
        };
        
        //chance = 14, 1s = 2, 2s = 2, 4s = 4, 6s = 6, pair = 2

        [Fact]
        public void ContainAListOfNonZeroScoresForEachCategory()
        {
            Assert.Equal(6, CategoryScore.GetSortedListOfNonZeroScores().Count());
        }

        [Theory]
        [InlineData("Chance", 14)]
        [InlineData("Ones", 2)]
        [InlineData("Twos", 2)]
        [InlineData("Fours", 4)]
        [InlineData("Sixes", 6)]
        [InlineData("Pair", 2)]
        public void CategoryScoreListContainsCorrectData(string category, int expectedScore)
        {
            var sut = CategoryScore.GetSortedListOfNonZeroScores();
            Assert.Equal(expectedScore, sut[category]);
        }

    }
}