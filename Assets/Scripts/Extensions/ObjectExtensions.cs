using UnityEngine;

namespace Matkanoid {

    public static class ObjectExtensions {

        public static T As<T>(this Object @object) {
            if (@object is T value) { return value; }
            if (@object is GameObject gameObject) { return gameObject.GetComponent<T>(); }
            return default;
        }
    }
}
