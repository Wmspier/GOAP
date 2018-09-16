using UnityEngine;
namespace GOAP
{
    [CreateAssetMenu(fileName = "NewPrecondition", menuName = "GOAP/Precondition", order = 3)]
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
