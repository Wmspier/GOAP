namespace GOAP
{
    public interface IResult
    {
     //   void Apply(ref Actor actor, ref BaseSubject subject);
        void Apply(ref SubjectData actorData, ref SubjectData subjectData);
    }
}
