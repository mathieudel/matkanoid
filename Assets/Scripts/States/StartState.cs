using UnityEngine;

namespace Matkanoid.States {

    public class StartState : MonoBehaviour, IState {

        [SerializeField] Object _gameplayState;

        IState gameplayState => _gameplayState.As<IState>();
        bool runnnig => _stateMachine != null;

        StateMachine _stateMachine;

        void OnValidate() => _gameplayState = gameplayState as Object;

        public void Run(StateMachine stateMachine) => _stateMachine = stateMachine;

        public void Stop() => _stateMachine = null;

        void Update() {
            if (runnnig && UnityEngine.Input.GetAxis("Fire1") > 0f) {
                _stateMachine.currentState = gameplayState;
            }
        }
    }
}
