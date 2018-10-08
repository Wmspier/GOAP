using System;
namespace GOAP
{
    public interface ISubject
    {
        float GetResource(Type resourceType);
        void ModifyResource(Type resourceType, float amount);
        bool HasState(State state);
        void ModifyState(State state, StateChange stateChange);
    }
}
