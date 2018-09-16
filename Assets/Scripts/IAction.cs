namespace GOAP
{
    public interface IAction
    {
        void Enter();
        void Exit();
        void Perform();
    }
}