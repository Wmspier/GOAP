using UnityEngine;
namespace GOAP
{
    public class BaseCondition : ScriptableObject, ICondition
    {
        public virtual bool IsMet(Actor actor)
        {
            return true;
        }
    }
}
