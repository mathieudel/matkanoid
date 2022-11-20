using UnityEngine;

namespace Matkanoid {

    using Input;

    public class Player : MonoBehaviour {

        [SerializeField] Paddle _paddle;
        [SerializeField] VirtualThumbstick _thumbstick;
        [SerializeField] AnimationCurve _speedMapping;

        void OnEnable() => _paddle.velocity = Vector2.zero;

        void OnDisable() => _paddle.velocity = Vector2.zero;

        void Update() {
            var movement = _thumbstick.value;
            _paddle.velocity = movement.normalized * _speedMapping.Evaluate(movement.magnitude);
        }
    }
}
