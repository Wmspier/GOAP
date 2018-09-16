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
    public class ResourcePrecondition<T> : BasePrecondition where T : BaseResource
    {
        public Comparison Comparison;
        public float Value;

        public ResourcePrecondition(IAgent agent) : base(agent){}

        public override bool IsMet()
        {
            var agentResource = _agent.GetResource<T>();
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
