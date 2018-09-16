namespace GOAP
{
    public class StatePostcondition : BasePostcondition
    {
        public State State;

        public StatePostcondition(IAgent agent) : base(agent) {}

        public override void Apply()
        {
        }
    }
}
