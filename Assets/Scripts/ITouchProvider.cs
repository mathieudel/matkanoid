using System.Collections.Generic;

using UnityEngine;

namespace Matkanoid {

  public interface ITouchProvider {

    int touchCount { get; }

    IReadOnlyList<Touch> touches { get; }
  }
}
