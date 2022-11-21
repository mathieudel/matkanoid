using UnityEngine;
using UnityEngine.SceneManagement;

namespace Matkanoid.States {

    public class WinState : MonoBehaviour, IState {

        [SerializeField] Popup _winPopup;

        public void Run(StateMachine stateMachine) {
            _winPopup.validated += OnWinPopupValidated;
            _winPopup.Open();
        }

        public void Stop() {
            _winPopup.validated += OnWinPopupValidated;
            if (!_winPopup.IsDestroyed()) {
                _winPopup.Close();
            }
        }

        void OnWinPopupValidated(Popup popup) => SceneManager.LoadScene(gameObject.scene.name);
    }
}
