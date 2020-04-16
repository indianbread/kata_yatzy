using System.Collections.Generic;
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
        
        
    }
}