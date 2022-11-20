using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Matkanoid.States {

    public class LoseState : MonoBehaviour, IState {

        [SerializeField] RectTransform _losePanel;
        [SerializeField] Button _restartButton;

        public void Run(StateMachine stateMachine) {
            _restartButton.onClick.AddListener(OnRestartClicked);
            _losePanel.gameObject.SetActive(true);
        }

        public void Stop() {
            _losePanel.gameObject.SetActive(false);
            _restartButton.onClick.RemoveListener(OnRestartClicked);
        }

        void OnRestartClicked() => SceneManager.LoadScene(gameObject.scene.name);
    }
}
