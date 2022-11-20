namespace Matkanoid.States {

    public interface IState {

        void Run(StateMachine stateMachine);

        void Stop();
    }
}
