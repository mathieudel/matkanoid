using System.Collections;

using UnityEngine;

namespace Matkanoid {

    public class Ball : MonoBehaviour {

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
    }
}
