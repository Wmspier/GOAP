using System;
using UnityEngine;
namespace GOAP
{
    public abstract class BaseResult : ScriptableObject, IResult
    {
        public virtual void Apply(ref Actor actor, ref BaseSubject subject)
        {
            Apply(ref actor.Data, ref subject.Data);
        }

        public abstract void Apply(ref SubjectData actorData, ref SubjectData subjectData);
    }
}
