using System;
using System.Collections.Generic;

namespace Matkanoid {

    public static class IReadonlyListExtensions {

        static readonly Random _defaultRandom = new Random();

        public static T GetRandom<T>(this IReadOnlyList<T> list, Random random = default) {
            return list[(random ?? _defaultRandom).Next(0, list.Count - 1)];
        }

        public static bool TryGetRandom<T>(this IReadOnlyList<T> list, out T value) => list.TryGetRandom(null, out value);

        public static bool TryGetRandom<T>(this IReadOnlyList<T> list, Random random, out T value) {
            if (list.Count > 0) {
                value = list.GetRandom(random);
                return true;
            }
            value = default;
            return false;
        }
    }
}
