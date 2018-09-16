using UnityEngine;
namespace GOAP
{
    [CreateAssetMenu(fileName = "NewPostcondition", menuName = "GOAP/Postcondition", order = 4)]
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
