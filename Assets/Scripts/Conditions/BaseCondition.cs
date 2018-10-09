using UnityEngine;
namespace GOAP
{
    public class BaseCondition : ScriptableObject, ICondition
    {
        public virtual bool IsMet(Actor actor)
        {
            return IsMet(actor.Data);
        }

        public virtual bool IsMet(SubjectData data)
        {
            return true;
        }

    }
}
