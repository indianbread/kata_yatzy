using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Yatzy
{
    public class Player
    {
        private List<Dice> _rolledDices = new List<Dice>();
        private int[] _myNumbers => _rolledDices.Select(dice => dice.GetValue()).ToArray();
        public List<Dice> RollDice()
        {
            for (int i = 0; i < _numOfDicePerHand; i++)
            {
                _rolledDices.Add(new Dice());
            }

            return _rolledDices;
        }
        
        // private MethodInfo[] GetAllCategories()
        // {
        //     MethodInfo[] methodInfos = typeof(Category).GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
        //     return methodInfos;
        // }
        //
        // public Dictionary<string, int> GetScoresForEachCategory()
        // {
        //     MethodInfo[] allMethods = GetAllCategories();
        //     Type categoryType = typeof(Category);
        //     ConstructorInfo categoryConstructor = categoryType.GetConstructor(new Type[]{typeof(int[])});
        //     if (categoryConstructor == null)
        //     {
        //         throw new ArgumentException("No constructor found");
        //     }
        //     object category = categoryConstructor.Invoke(new object[] {_myNumbers});
        //     Dictionary<string, int> methodsWithScore = new Dictionary<string, int>();
        //     foreach (var method in allMethods)
        //     {
        //
        //         methodsWithScore.Add(method.Name, (int) method.Invoke(category, null));
        //
        //     }
        //     
        //     return methodsWithScore;
        //
        // }
        
        private const int _numOfDicePerHand = 5;
    }
}