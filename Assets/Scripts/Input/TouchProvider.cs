using System.Collections.Generic;

using UnityEngine;

namespace Matkanoid.Input {

    using Input = UnityEngine.Input;

    public class TouchProvider : ITouchProvider {

        public int touchCount => Input.touchCount;

        public IReadOnlyList<Touch> touches => Input.touches;
    }
}
