﻿using UnityEngine;
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

    [CreateAssetMenu(fileName = "ResourcePrecondition", menuName = "GOAP/Precondition/Resource Precondition", order = 0)]
    public class ResourceCondition : BaseCondition
    {
        public BaseResource Resource;
        public Comparison Comparison;
        public float Value;

        public override bool IsMet(Actor actor)
        {
            var agentResource = actor.GetResource(Resource.GetType());
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