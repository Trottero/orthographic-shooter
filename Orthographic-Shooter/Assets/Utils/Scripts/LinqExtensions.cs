using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OrthographicShooter.Utils
{
    public static class LinqExtensions
    {
        public static T MinBy<T>(this IEnumerable<T> collection, Func<T, IComparable> keySelector)
        {
            T min = collection.First();
            IComparable minValue = keySelector(collection.First());
            foreach (var item in collection)
            {
                var potentialMin = keySelector(item);
                if (minValue.CompareTo(potentialMin) > 0)
                {
                    min = item;
                    minValue = potentialMin;
                }
            }
            return min;
        }

        public static T MaxBy<T>(this IEnumerable<T> collection, Func<T, IComparable> keySelector)
        {
            T max = collection.First();
            IComparable maxValue = keySelector(collection.First());
            foreach (var item in collection)
            {
                var potentialmax = keySelector(item);
                if (potentialmax.CompareTo(maxValue) > 0)
                {
                    max = item;
                    maxValue = potentialmax;
                }
            }
            return max;
        }
    }
}
