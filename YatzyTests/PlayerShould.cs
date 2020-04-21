using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yatzy;

namespace Yatzy.Test
{
    public class PlayerShould
    {
        public PlayerShould()
        {
            Player = new Player();
        }

        public Player Player;
        
        [Fact]
        public void ReturnAListOfRolledValues()
        {
            var actual = Player.RollDice();

            Assert.Equal(5, actual.Count);
            
        }
        
        [Fact]
        public void ReturnedDiceValuesBetween1And6()
        {
            var actual = Player.RollDice();
            foreach (var dice in actual)
            {
               Assert.True(dice.GetValue() >= 1 && dice.GetValue() <= 6); 
            }
            
        }
        
         // [Fact]
         // public void StoreAListOfScoresForEachCategory()
         // {
         //     Player.RollDice();
         //     Assert.Equal(15, Player.GetScoresForEachCategory().Count);
         // }
         //
         // [Fact]
         // public void CategoryScoreListContainsCorrectData()
         // {
         //     Player.RollDice();
         //     var sut = Player.GetScoresForEachCategory();
         //     var actualCountOfScoresGreaterThanZero = sut.Count(item => item.Value > 2);
         //     
         //     Assert.True(actualCountOfScoresGreaterThanZero > 0);
         //
         // }

        
    }
}