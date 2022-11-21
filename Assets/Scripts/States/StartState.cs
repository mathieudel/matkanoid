using UnityEngine;

namespace Matkanoid.States {

    public class StartState : MonoBehaviour, IState {

        [SerializeField] Object _gameplayState;
        [SerializeField] Popup _startPopup;

        IState gameplayState => _gameplayState.As<IState>();

        StateMachine _stateMachine;

        void OnValidate() => _gameplayState = gameplayState as Object;

        public void Run(StateMachine stateMachine) {
            _stateMachine = stateMachine;
            _startPopup.validated += OnStartPopupValidated;
            _startPopup.Open();
        }

        public void Stop() {
            _startPopup.validated -= OnStartPopupValidated;
            _startPopup.Close();
            _stateMachine = null;
        }

        void OnStartPopupValidated(Popup popup) {
            _stateMachine.currentState = gameplayState;
        }
    }
}
