namespace GOAP
{
    public enum Change
    {
        Add,
        Remove
    }
    public class ResourcePostcondition : BasePostcondition
    {
        public BaseResource Resource;
        public float Amount;
        public Change ChangeOperation;

        public ResourcePostcondition(IAgent agent) : base(agent) {}

        public override void Apply()
        {
            _agent.ModifyResource<>
            agentResource.Value = ChangeOperation == Change.Add ? agentResource.Value + Amount : agentResource.Value - Amount;
        }
    }
}
