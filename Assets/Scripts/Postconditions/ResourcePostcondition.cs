namespace GOAP
{
    public enum Change
    {
        Add,
        Remove
    }
    public class ResourcePostcondition<T> : BasePostcondition where T : BaseResource
    {
        public float Amount;
        public Change ChangeOperation;

        public ResourcePostcondition(IAgent agent) : base(agent) {}

        public override void Apply()
        {
            _agent.ModifyResource<T>(Amount);
        }
    }
}
