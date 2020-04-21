using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Yatzy
{
    public class CategoryScore
    {
        public CategoryScore(List<Dice> dices)
        {
            DiceNumbers = dices.Select(dice => dice.GetValue()).ToArray();
        }

        private int[] _diceNumbers = new int[5];

        public int[] DiceNumbers
        {
            get => _diceNumbers;
            set => _diceNumbers = value;
        }

        private MethodInfo[] GetAllCategories()
        {
            MethodInfo[] methodInfos = typeof(Category).GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
            return methodInfos;
        }

        public Dictionary<string, int> GetScoresForEachCategory()
        {
            MethodInfo[] allMethods = GetAllCategories();
            Type categoryType = typeof(Category);
            ConstructorInfo categoryConstructor = categoryType.GetConstructor(new Type[]{typeof(int[])});
            if (categoryConstructor == null)
            {
                throw new ArgumentException("No constructor found");
            }
            object category = categoryConstructor.Invoke(new object[] {DiceNumbers});
            Dictionary<string, int> methodsWithScore = new Dictionary<string, int>();
            foreach (var method in allMethods)
            {

                methodsWithScore.Add(method.Name, (int) method.Invoke(category, null));

            }
            
            return methodsWithScore;

        }

            
    }
}