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

        public Dictionary<string, int> GetSortedListOfNonZeroScores()
        {
            var listOfNonZeroScores = GetCategoriesWithNonZeroScores();
            return listOfNonZeroScores.OrderByDescending(item => item.Value)
                                      .ToDictionary(pair => pair.Key, pair => pair.Value);
        }


        private MethodInfo[] GetAllCategories()
        {
            MethodInfo[] categoryMethods = typeof(Category).GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
            return categoryMethods;
        }

        private Dictionary<string, int> GetScoresForAllCategories()
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
            allMethods.ToList().ForEach(method => methodsWithScore.Add(method.Name, (int) method.Invoke(category, null)));
            return methodsWithScore;

        }

        private Dictionary<string, int> GetCategoriesWithNonZeroScores()
        {
            var categoryScores = GetScoresForAllCategories();
            return categoryScores.Where(item => item.Value > 0)
                                 .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

    }
}