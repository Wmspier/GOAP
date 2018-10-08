using UnityEngine;
namespace GOAP
{
    public enum Change
    {
        Add,
        Remove
    }

    [CreateAssetMenu(fileName = "ResourcePostcondition", menuName = "GOAP/Postcondition/Resource Postcondition", order = 1)]
    public class ResourceResult : BaseResult
    {
        public BaseResource Resource;
        public float Amount;
        public Change ChangeOperation;

        public override void Apply(Actor actor, BaseSubject subject)
        {
            actor.ModifyResource(Resource.GetType(), Amount);
        }
    }
}
