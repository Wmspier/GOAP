using System;
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
    public class ResourcePrecondition : BasePrecondition
    {
        public string ResourceTag;
        public BaseResource Resource;
        public Comparison Comparison;
        public float Value;

        public ResourcePrecondition(IAgent agent) : base(agent){}

        public override bool IsMet()
        {
            var agentResource = _agent.GetResource(ResourceTag);
            if (!agentResource)
                return false;
            switch (Comparison)
            {
                case Comparison.Less:
                    return agentResource.Value < Value;
                case Comparison.LessOrEqual:
                    return agentResource.Value < Value || agentResource.Value.Equals(Value);
                case Comparison.Equal:
                    return agentResource.Value.Equals(Value);
                case Comparison.MoreOrEqual:
                    return agentResource.Value > Value || agentResource.Value.Equals(Value);
                case Comparison.More:
                    return agentResource.Value > Value;
            }
            return false;
        }
    }
}
