using System;
using System.Collections.Generic;

namespace Matkanoid {

  public static class IEnumerableExtensions {

    public static bool TryGetFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, out T result) {
      foreach (var value in enumerable) {
        if (predicate(value)) {
          result = value;
          return true;
        }
      }
      result = default;
      return false;
    }
  }
}
