using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace Yatzy.Test
{
    public class PlayerShould
    {
        [Fact]
        public void ReturnAListOfRolledValues()
        {
            var testPlayer = new Player();
            var actual = testPlayer.RollDice();

            Assert.Equal(5, actual.Count);
            
        }
        
        [Fact]
        public void ReturnedDiceValuesBetween1And6()
        {
            var testPlayer = new Player();
            var actual = testPlayer.RollDice();
            foreach (var dice in actual)
            {
               Assert.True(dice.GetValue() >= 1 && dice.GetValue() <= 6); 
            }
            
        }
        
        
    }
}