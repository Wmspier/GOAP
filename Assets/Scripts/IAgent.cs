using System;
namespace GOAP
{
    public interface IAgent
    {
        float GetResource(Type resourceType);
        void ModifyResource(Type resourceType, float amount);
        bool HasState(string name);
    }
}
