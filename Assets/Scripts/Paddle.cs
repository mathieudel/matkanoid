using System.Collections;

using UnityEngine;

namespace Matkanoid {

    public class Paddle : MonoBehaviour {

        [SerializeField] Collider2D _collider;
        [SerializeField] BoxCollider2D _moveArea;

        public void SetPosition(Vector3 position) => StartCoroutine(UpdatePosition(position));

        IEnumerator UpdatePosition(Vector3 position) {
            yield return new WaitForFixedUpdate();
            var moveBounds = _moveArea.bounds;
            var bounds = _collider.bounds;
            bounds.center = position;

            transform.position = position
                + Vector3.Max(Vector3.zero, moveBounds.min - bounds.min)
                - Vector3.Max(Vector3.zero, bounds.max - moveBounds.max);
        }
    }
}
