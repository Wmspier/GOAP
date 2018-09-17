using UnityEngine;
namespace GOAP
{
    public class BasePrecondition : ScriptableObject, IPrecondition
    {
        protected IAgent _agent;
        public BasePrecondition(IAgent agent)
        {
            _agent = agent;
        }

        public virtual bool IsMet()
        {
            return true;
        }
    }
}
