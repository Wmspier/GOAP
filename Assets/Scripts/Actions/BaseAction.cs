using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
namespace GOAP
{
    public enum Difficulty
    {
        Effortless = 1,
        Easy,
        Medium,
        Hard
    }

    [Serializable]
    [CreateAssetMenu(fileName = "NewAction", menuName = "GOAP/Action", order = 1)]
    public class BaseAction : ScriptableObject, IAction
    {
        public List<BaseCondition> Conditions = new List<BaseCondition>();
        public List<BaseResult> Results = new List<BaseResult>();
        public Difficulty Difficulty;

        public virtual bool Enter(Actor actor)
        {
            return !Conditions.Any(c => !c.IsMet(actor));
        }
        public virtual void Exit(Actor actor)
        {
            //  TODO aherrera : DUMMY! HE'S GOT A KNIFE.
            var dummySubject = new SubjectData();

            foreach(var result in Results)
            {
                result.Apply(ref actor.Data, ref dummySubject);
            }
        }
        public virtual bool Perform(Actor actor)
        {
            return true;
        }
        public virtual bool IsComplete()
        {
            return true;
        }
    }
}
