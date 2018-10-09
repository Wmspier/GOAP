using System;
namespace GOAP
{
    public interface ISubject
    {
        float GetResource(string resourceType);
        void ModifyResource(string resourceType, float amount);
        bool HasState(State state);
        void ModifyState(State state, StateChange stateChange);
    }
}
