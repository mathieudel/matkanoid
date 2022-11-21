using System.Collections;

using UnityEngine;

namespace Matkanoid {

    public class Ball : MonoBehaviour {

        [SerializeField] AnimationCurve _bounceRandomnessByHorizontalSpeed;

        public Vector2 velocity {
            get => _rigidBody.velocity;
            set {
                StopAllCoroutines();
                StartCoroutine(SetVelocity(value));
            }
        }

        Rigidbody2D _rigidBody;

        void Awake() => _rigidBody = GetComponent<Rigidbody2D>();

        IEnumerator SetVelocity(Vector2 velocity) {
            yield return new WaitForFixedUpdate();
            _rigidBody.velocity = velocity;
        }

        void OnCollisionEnter2D(Collision2D collision) {
            var speedSign = Mathf.Approximately(velocity.x, 0f) ? 1f : Mathf.Sign(velocity.x);
            var bounceRandomness = _bounceRandomnessByHorizontalSpeed.Evaluate(Mathf.Abs(velocity.x));
            var force = Random.Range(0f, bounceRandomness) * Vector2.right * speedSign;
            _rigidBody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
