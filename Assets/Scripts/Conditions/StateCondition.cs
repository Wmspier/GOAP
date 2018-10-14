using System.Linq;
using UnityEngine;
namespace GOAP
{
    [CreateAssetMenu(fileName = "StateCondition", menuName = "GOAP/Condition/State Condition", order = 1)]
    public class StateCondition : BaseCondition
    {
        public State State;
        public bool ShouldHave = true;

        public override bool IsMet(Actor actor)
        {
            return actor.HasState(State) && ShouldHave;
        }

        public override bool IsMet(SubjectData data)
        {
            return data.States.FirstOrDefault(s => s.GetType() == State.GetType()) != null;
        }
    }
}
