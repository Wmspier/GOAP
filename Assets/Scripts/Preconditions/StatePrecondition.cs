namespace GOAP
{
    public class StatePrecondition : BasePrecondition
    {
        public string State;
        public bool ShouldHave = true;

        public StatePrecondition(IAgent agent) : base(agent) { }

        public override bool IsMet()
        {
            return _agent.HasState(State) && ShouldHave;
        }
    }
}
