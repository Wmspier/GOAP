using UnityEngine;
namespace GOAP
{
    public enum StateChange
    {
        Lose,
        Gain
    }
    [CreateAssetMenu(fileName = "StatePostcondition", menuName = "GOAP/Postcondition/State Postcondition", order = 0)]
    public class StateResult : BaseResult
    {
        public State State;
        public StateChange StateChange;

        public override void Apply(ref Actor actor, ref BaseSubject subject)
        {
            //  TODO aherrera : reevaulate and see if it meets SubjectData structure -- see IResult

            actor.ModifyState(State, StateChange);
        }
    }
}
