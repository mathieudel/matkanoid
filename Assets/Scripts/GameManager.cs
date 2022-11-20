using UnityEngine;

namespace Matkanoid {

    using States;

    public class GameManager : MonoBehaviour {

        [SerializeField] Object _startState;

        IState startState => _startState.As<IState>();
        StateMachine _stateMachine;

        void OnValidate() => _startState = startState as Object;

        void OnEnable() {
            _stateMachine = new StateMachine();
            _stateMachine.currentState = startState;
        }

        void OnDisable() {
            _stateMachine.currentState = null;
            _stateMachine = null;
        }
    }
}
