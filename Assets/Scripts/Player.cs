using UnityEngine;

namespace Matkanoid {

    using Input;

    public class Player : MonoBehaviour {

        [SerializeField] Paddle _paddle;
        [SerializeField] AnimationCurve _velocityMapping;

        Vector2 _touchStartPosition;

        ITouchProvider _touchProvider;

        void Awake() {
            // Should be injected by IoC
            _touchProvider = Application.isEditor ? new MouseAsTouchProvider() : (ITouchProvider) new TouchProvider();
        }

        void Update() {
            if (_touchProvider.touchCount == 0) { return; }

            var touch = _touchProvider.touches[0];

            switch (touch.phase) {
                case TouchPhase.Began:
                    _touchStartPosition = touch.position;
                    _paddle.velocity = GetPaddleVelocity(touch.position);
                break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    _paddle.velocity = GetPaddleVelocity(touch.position);
                break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _paddle.velocity = Vector2.zero;
                break;
            }
        }

        Vector2 GetPaddleVelocity(Vector2 touchPosition) {
            var movement = (touchPosition - _touchStartPosition) / Screen.width;
            return movement.normalized * _velocityMapping.Evaluate(movement.magnitude);
        }
    }
}
