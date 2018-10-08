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

        public override void Apply(Actor actor, BaseSubject subject)
        {
            actor.ModifyState(State, StateChange);
        }
    }
}
