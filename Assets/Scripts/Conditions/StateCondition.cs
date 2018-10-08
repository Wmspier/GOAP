using UnityEngine;
namespace GOAP
{
    [CreateAssetMenu(fileName = "StatePrecondition", menuName = "GOAP/Precondition/State Precondition", order = 1)]
    public class StateCondition : BaseCondition
    {
        public State State;
        public bool ShouldHave = true;

        public override bool IsMet(Actor actor)
        {
            return actor.HasState(State) && ShouldHave;
        }
    }
}
