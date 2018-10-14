using System;
using System.Linq;
using UnityEngine;
namespace GOAP
{
    public enum StateChange
    {
        Lose,
        Gain
    }
    [CreateAssetMenu(fileName = "StateResult", menuName = "GOAP/Result/State Result", order = 0)]
    public class StateResult : BaseResult
    {
        public State State;
        public StateChange StateChange;

        public override void Apply(ref SubjectData actorData, ref SubjectData subjectData)
        {
            if (StateChange == StateChange.Gain && actorData.States.FirstOrDefault(s => s.GetType() == State.GetType()) == null)
                actorData.States.Add(State);
            else if (StateChange == StateChange.Lose)
            {
                actorData.States.Remove(actorData.States.FirstOrDefault(s => s.GetType() == State.GetType()));
            }
        }

        public override void Apply(ref Actor actor, ref BaseSubject subject)
        {
            //  TODO aherrera : reevaulate and see if it meets SubjectData structure -- see IResult

            actor.ModifyState(State, StateChange);
        }
    }
}
