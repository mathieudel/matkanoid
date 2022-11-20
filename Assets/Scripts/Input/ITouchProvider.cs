using System.Collections.Generic;

using UnityEngine;

namespace Matkanoid.Input {

  public interface ITouchProvider {

    int touchCount { get; }

    IReadOnlyList<Touch> touches { get; }
  }
}
