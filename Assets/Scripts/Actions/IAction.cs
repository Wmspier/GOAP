using System;
namespace GOAP
{
    public interface IAction
    {
        bool Enter();
        void Exit();
        bool Perform();
        bool IsComplete();
    }
}