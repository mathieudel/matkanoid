using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Matkanoid.States {

    public class LoseState : MonoBehaviour, IState {

        [SerializeField] Popup _losePopup;

        public void Run(StateMachine stateMachine) {
            _losePopup.validated += OnLosePopupValidated;
            _losePopup.Open();
        }

        public void Stop() {
            _losePopup.validated += OnLosePopupValidated;
            if (!_losePopup.IsDestroyed()) {
                _losePopup.Close();
            }
        }

        void OnLosePopupValidated(Popup popup) => SceneManager.LoadScene(gameObject.scene.name);
    }
}
