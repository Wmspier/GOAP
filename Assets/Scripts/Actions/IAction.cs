using System;
namespace GOAP
{
    public interface IAction
    {
        bool Enter(Actor actor);
        void Exit(Actor actor);
        bool Perform(Actor actor);
        bool IsComplete();
    }
}