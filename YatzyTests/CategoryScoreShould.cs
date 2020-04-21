using Xunit;
using System;
using System.Linq;
using Yatzy;

namespace Yatzy.Test
{
    public class CategoryScoreShould
    {
        public CategoryScoreShould()
        {
            Player = new Player();
            CategoryScore = new CategoryScore(Player.RollDice());
        }

        public Player Player;
        public CategoryScore CategoryScore;
        
        [Fact]
        public void StoreAListOfScoresForEachCategory()
        {
            Player.RollDice();
            Assert.Equal(15, CategoryScore.GetScoresForEachCategory().Count);
        }

        [Fact]
        public void CategoryScoreListContainsCorrectData()
        {
            var sut = CategoryScore.GetScoresForEachCategory();
            var actualCountOfScoresGreaterThanZero = sut.Count(item => item.Value > 2);
            
            Assert.True(actualCountOfScoresGreaterThanZero > 0);

        }

    }
}