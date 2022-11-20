using UnityEngine;

namespace Matkanoid.Input {

    public class VirtualThumbstick : MonoBehaviour {

        [SerializeField] Camera _referenceCamera;
        [SerializeField] int _fingerId;

        Vector2 _value;
        public Vector2 value { get {
            var frameCount = Time.frameCount;
            if (_currentFrameCount != frameCount) {
                _currentFrameCount = frameCount;
                UpdateValue();
            }
            return _value;
        }}

        int _currentFrameCount;
        Vector2 _touchStartPosition;

        ITouchProvider _touchProvider;
        RectTransform _rectTransform;

        void Awake() {
            // Should be injected by IoC
            _touchProvider = Application.isEditor ? new MouseAsTouchProvider() : (ITouchProvider) new TouchProvider();
            _rectTransform = GetComponent<RectTransform>();
        }

        void UpdateValue() {
            if (!_touchProvider.touches.TryGetFirst(touch => touch.fingerId == _fingerId, out var touch)) {
                return;
            }

            var hit = RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform, touch.position, _referenceCamera, out var localPosition
            );

            if (!hit) { return; }

            switch (touch.phase) {
                case TouchPhase.Began:
                    _touchStartPosition = localPosition;
                    _value = GetValue(localPosition);
                break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    _value = GetValue(localPosition);
                break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _touchStartPosition = Vector2.zero;
                    _value = GetValue(Vector2.zero);
                break;
            }
        }

        Vector2 GetValue(Vector2 position) {
            var movement = position - _touchStartPosition;
            var size = _rectTransform.rect.size;
            return new Vector2(movement.x / size.x, movement.y / size.y);
        }
    }
}
