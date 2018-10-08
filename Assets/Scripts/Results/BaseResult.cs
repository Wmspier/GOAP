using UnityEngine;
namespace GOAP
{
    public class BaseResult : ScriptableObject
    {
        public virtual void Apply(Actor actor, BaseSubject subject){}
    }
}
