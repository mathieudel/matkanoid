using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Matkanoid.States {

    public class WinState : MonoBehaviour, IState {

        [SerializeField] RectTransform _winPanel;
        [SerializeField] Button _restartButton;

        public void Run(StateMachine stateMachine) {
            _restartButton.onClick.AddListener(OnRestartClicked);
            _winPanel.gameObject.SetActive(true);
        }

        public void Stop() {
            if (!_winPanel.IsDestroyed()) { _winPanel.gameObject.SetActive(false); }

            _restartButton.onClick.RemoveListener(OnRestartClicked);
        }

        void OnRestartClicked() => SceneManager.LoadScene(gameObject.scene.name);
    }
}
