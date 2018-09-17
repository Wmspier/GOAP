using UnityEngine;
using System.Collections.Generic;
namespace GOAP
{
    public enum Difficulty
    {
        Effortless = 0,
        Easy,
        Medium,
        Hard
    }

    [CreateAssetMenu(fileName = "NewAction", menuName = "GOAP/Action", order = 1)]
    public class BaseAction : ScriptableObject, IAction
    {
        public List<BasePrecondition> Preconditions;
        public List<BasePostcondition> Postconditions;
        public Difficulty Difficulty;
        public ISubject Subject;

        public virtual void Enter(){}
        public virtual void Exit(){}
        public virtual void Perform(){}
    }
}
