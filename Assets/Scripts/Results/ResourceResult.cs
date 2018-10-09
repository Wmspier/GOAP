using UnityEngine;
namespace GOAP
{
    public enum Change
    {
        Add,
        Remove
    }

    [CreateAssetMenu(fileName = "ResourceResult", menuName = "GOAP/Result/Resource Result", order = 1)]
    public class ResourceResult : BaseResult
    {
        public BaseResource Resource;
        public float Amount;
        public Change ChangeOperation;

        public override void Apply(ref Actor actor, ref BaseSubject subject)
        {
            //  TODO aherrera : reevaulate and see if it meets SubjectData structure -- see IResult

            actor.ModifyResource(Resource.Name, Amount);
        }
    }
}
