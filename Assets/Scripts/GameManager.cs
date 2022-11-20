using System.Collections;

using UnityEngine;

namespace Matkanoid {

    public class GameManager : MonoBehaviour {

        [SerializeField] Ball _ball;
        [SerializeField] Vector2 _startVelocity;

        void OnEnable() => StartCoroutine(StartGame());

        IEnumerator StartGame() {
            yield return new WaitForFixedUpdate();
            _ball.GetComponent<Rigidbody2D>().velocity = _startVelocity;
        }
    }
}
