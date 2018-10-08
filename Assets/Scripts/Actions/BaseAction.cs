using UnityEngine;
using System.Collections.Generic;
using System.Linq;
namespace GOAP
{
    public enum Difficulty
    {
        Effortless = 1,
        Easy,
        Medium,
        Hard
    }

    [CreateAssetMenu(fileName = "NewAction", menuName = "GOAP/Action", order = 1)]
    public class BaseAction : ScriptableObject, IAction
    {
        public List<BaseCondition> Conditions = new List<BaseCondition>();
        public List<BaseResult> Results = new List<BaseResult>();
        public Difficulty Difficulty;
        public BaseSubject Subject;
        public Actor Actor;

        public virtual bool Enter()
        {
            return !Conditions.Any(c => !c.IsMet(Actor));
        }
        public virtual void Exit(){}
        public virtual bool Perform()
        {
            return true;
        }
        public virtual bool IsComplete()
        {
            return true;
        }
    }
}
