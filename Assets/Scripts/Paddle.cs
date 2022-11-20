using UnityEngine;

namespace Matkanoid {

    public class Paddle : MonoBehaviour {

        [SerializeField] Collider2D _collider;
        [SerializeField] BoxCollider2D _moveArea;
        [SerializeField] float _maxSpeed;

        Vector2 _velocity;
        public Vector2 velocity {
            get => _velocity;
            set => _velocity = Mathf.Min(value.magnitude, _maxSpeed) * value.normalized;
        }

        void FixedUpdate() {
            var moveBounds = _moveArea.bounds;
            var bounds = _collider.bounds;
            bounds.center = transform.position + (Vector3) (velocity * Time.fixedDeltaTime);

            transform.position = bounds.center
                + Vector3.Max(Vector3.zero, moveBounds.min - bounds.min)
                - Vector3.Max(Vector3.zero, bounds.max - moveBounds.max);
        }
    }
}
