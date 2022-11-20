using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Matkanoid {

    public class GameManager : MonoBehaviour {

        [SerializeField] Ball _ball;
        [SerializeField] TriggerEvent2D _voidEvent;
        [SerializeField] Vector2 _ballStartVelocity;

        void OnEnable() {
            _voidEvent.entered += OnEnteredVoid;
            StartCoroutine(StartGame());
        }

        void OnDisable() => _voidEvent.entered -= OnEnteredVoid;

        void OnEnteredVoid(TriggerEvent2D trigger, Collider2D collider) {
            if (collider.gameObject == _ball.gameObject) {
                ResetGame();
            }
        }

        IEnumerator StartGame() {
            yield return new WaitForFixedUpdate();
            _ball.GetComponent<Rigidbody2D>().velocity = _ballStartVelocity;
        }

        void ResetGame() => SceneManager.LoadScene(gameObject.scene.name);
    }
}
