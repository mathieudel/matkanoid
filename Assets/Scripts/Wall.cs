using System;
using System.Linq;

using UnityEngine;

namespace Matkanoid {

    public class Wall : MonoBehaviour {

        public event Action<Wall> destroyed;

        public bool isDestroyed { get; private set; }

        Brick[] _bricks;

        void Awake() => _bricks = GetComponentsInChildren<Brick>();

        void OnEnable() {
            foreach (var brick in _bricks) {
                brick.broken += OnBrickBrocken;
            }
        }

        void OnDisable() {
            foreach (var brick in _bricks) {
                brick.broken -= OnBrickBrocken;
            }
        }

        void OnBrickBrocken(Brick brick) {
            isDestroyed = _bricks.All(brick => brick.isBroken);
            if (isDestroyed) {
                destroyed?.Invoke(this);
            }
        }
    }
}
