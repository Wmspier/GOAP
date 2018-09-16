using System;
namespace GOAP
{
    public interface IAgent
    {
        BaseResource GetResource<T>();
        void ModifyResource<T>(float amount);
        bool HasState(string name);
    }
}
