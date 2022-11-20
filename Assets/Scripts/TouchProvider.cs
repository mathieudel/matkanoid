using System.Collections.Generic;

using UnityEngine;

namespace Matkanoid {

  public class TouchProvider : ITouchProvider {

    public int touchCount => Input.touchCount;

    public IReadOnlyList<Touch> touches => Input.touches;
  }
}
