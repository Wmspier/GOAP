using UnityEngine;
namespace GOAP
{
    public class BasePostcondition : ScriptableObject
    {
        protected IAgent _agent;
        public BasePostcondition(IAgent agent)
        {
            _agent = agent;
        }
        public virtual void Apply(){}
    }
}
