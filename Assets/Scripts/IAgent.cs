using System;
namespace GOAP
{
    public interface IAgent
    {
        float GetResource<T>();
        void ModifyResource<T>(float amount);
        bool HasState(string name);
    }
}
