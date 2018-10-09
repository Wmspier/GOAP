using System;
using UnityEngine;
namespace GOAP
{
    public class BaseResult : ScriptableObject, IResult
    {
        public virtual void Apply(ref Actor actor, ref BaseSubject subject)
        {
            Apply(ref actor.Data, ref subject.Data);
        }

        public virtual void Apply(ref SubjectData actorData, ref SubjectData subjectData)
        {
            //  TODO aherrera : apply changes to data
        }
    }
}
