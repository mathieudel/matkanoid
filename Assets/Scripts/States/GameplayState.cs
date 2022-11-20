using System.Collections;
using System.Linq;

using UnityEngine;

namespace Matkanoid.States {

    public class GameplayState : MonoBehaviour, IState {

        [SerializeField] Player _player;
        [SerializeField] Ball _ball;
        [SerializeField] Vector2 _ballStartVelocity;

        [Space, SerializeField] TriggerEvent2D _voidTrigger;
        [SerializeField] Wall[] _walls;

        [Space, SerializeField] Object _winState;
        [SerializeField] Object _loseState;

        IState winState => _winState.As<IState>();
        IState loseState => _loseState.As<IState>();

        StateMachine _stateMachine;

        void OnValidate() {
            _winState = winState as Object;
            _loseState = loseState as Object;
        }

        public void Run(StateMachine stateMachine) {
            _stateMachine = stateMachine;
            _voidTrigger.entered += OnVoidEntered;
            foreach (var wall in _walls) {
                wall.destroyed += OnWallDestroyed;
            }
            _ball.velocity = _ballStartVelocity;
            _player.enabled = true;
        }

        public void Stop() {
            _player.enabled = false;
            _ball.velocity = Vector2.zero;
            _voidTrigger.entered -= OnVoidEntered;
            foreach (var wall in _walls) {
                wall.destroyed -= OnWallDestroyed;
            }
        }

        void OnVoidEntered(TriggerEvent2D trigger, Collider2D collider) {
            if (collider.gameObject == _ball.gameObject) {
                ResetGame();
            }
        }

        void OnWallDestroyed(Wall wall) {
            if (_walls.All(wall => wall.isDestroyed)) {
                _stateMachine.currentState = winState;
            }
        }

        void ResetGame() => _stateMachine.currentState = loseState;
    }
}
