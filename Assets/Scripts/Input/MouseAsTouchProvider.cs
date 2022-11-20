using System.Collections.Generic;

using UnityEngine;

namespace Matkanoid.Input {

  using Input = UnityEngine.Input;

  // Just enough logic to emulate touches in editor
  public class MouseAsTouchProvider : ITouchProvider {

    public int touchCount => touches.Count;

    List<Touch> _touches = new List<Touch>();
    public IReadOnlyList<Touch> touches { get {
      if (_currentFrame != Time.frameCount) {
        _currentFrame = Time.frameCount;
        UpdateTouches();
      }

      return _touches;
    }}

    TouchPhase[] _touchPhases = new TouchPhase[] { TouchPhase.Ended, TouchPhase.Ended, TouchPhase.Ended };

    int _currentFrame;

    void UpdateTouches() {
      _touches.Clear();
      for (var i = 0; i < 3; i++) {
        UpdateTouch(i, Input.GetMouseButton(i));
      }
    }

    void UpdateTouch(int index, bool pressed) {
      var previousTouchPhase = _touchPhases[index];
      if (pressed) {
        var touchPhase = previousTouchPhase == TouchPhase.Ended ? TouchPhase.Began : TouchPhase.Moved;
        _touchPhases[index] = touchPhase;
        _touches.Add(GetTouch(index, Input.mousePosition, touchPhase));

      } else if (previousTouchPhase != TouchPhase.Ended) {
        _touchPhases[index] = TouchPhase.Ended;
        _touches.Add(GetTouch(index, Input.mousePosition, TouchPhase.Ended));
      }
    }

    Touch GetTouch(int fingerId, Vector2 position, TouchPhase phase) {
      return new Touch {
        fingerId = fingerId,
        position = position,
        rawPosition = position,
        phase = phase
      };
    }
  }
}
