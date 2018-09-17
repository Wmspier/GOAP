using UnityEngine;
namespace GOAP
{
    public enum Change
    {
        Add,
        Remove
    }

    [CreateAssetMenu(fileName = "ResourcePostcondition", menuName = "GOAP/Resource Postcondition", order = 3)]
    public class ResourcePostcondition : BasePostcondition
    {
        public BaseResource Resource;
        public float Amount;
        public Change ChangeOperation;

        public ResourcePostcondition(IAgent agent) : base(agent) {}

        public override void Apply()
        {
            _agent.ModifyResource(Resource.GetType(), Amount);
        }
    }
}
