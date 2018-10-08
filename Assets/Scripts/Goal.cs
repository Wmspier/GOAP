using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace GOAP
{
    public class Goal : ScriptableObject
    {
        public List<ICondition> DesiredConditions = new List<ICondition>();

        public bool IsFullfilled(Actor actor)
        {
            return !DesiredConditions.Any(c => !c.IsMet(actor));
        }
    }
}