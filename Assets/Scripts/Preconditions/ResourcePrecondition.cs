using UnityEngine;
namespace GOAP
{
    public enum Comparison
    {
        Less,
        LessOrEqual,
        Equal,
        MoreOrEqual,
        More
    }

    [CreateAssetMenu(fileName = "ResourcePrecondition", menuName = "GOAP/Resource Precondition", order = 3)]
    public class ResourcePrecondition : BasePrecondition
    {
        public BaseResource Resource;
        public Comparison Comparison;
        public float Value;

        public ResourcePrecondition(IAgent agent) : base(agent){}

        public override bool IsMet()
        {
            var agentResource = _agent.GetResource(Resource.GetType());
            switch (Comparison)
            {
                case Comparison.Less:
                    return agentResource < Value;
                case Comparison.LessOrEqual:
                    return agentResource < Value || agentResource.Equals(Value);
                case Comparison.Equal:
                    return agentResource.Equals(Value);
                case Comparison.MoreOrEqual:
                    return agentResource > Value || agentResource.Equals(Value);
                case Comparison.More:
                    return agentResource > Value;
            }
            return false;
        }
    }
}
