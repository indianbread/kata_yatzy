using System;
using Xunit;
using Yatzy;

namespace Yatzy.Test
{
    public class DiceShould
    {
        [Theory]
        [InlineData(6)]
        public void GetValueReturnsAValue(int expectedValue)
        {
            var dice = new Dice(expectedValue);
            var actual = dice.GetValue();
            
            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData(5)]
        public void GetValueReturns5(int expectedValue)
        {
            var dice = new Dice(expectedValue);
            var actual = dice.GetValue();
            
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void GetValueReturnsRandomValue()
        {
            var dice = new Dice();
            Assert.True(dice.GetValue() >= 1 && dice.GetValue() <= 6);
        }
        
        
    }
}