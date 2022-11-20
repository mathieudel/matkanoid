namespace Matkanoid.States {

    public class StateMachine {

        IState _currentState;
        public IState currentState {
            get => _currentState;
            set {
                if (_currentState != null) {
                    _currentState.Stop();
                }
                _currentState = value;
                if (_currentState != null) {
                    _currentState.Run(this);
                }
            }
        }
    }
}
