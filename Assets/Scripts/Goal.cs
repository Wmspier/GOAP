using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace GOAP
{
    [CreateAssetMenu(fileName = "Goal", menuName = "GOAP/Goal/Basic Goal", order = 0)]
    public class Goal : ScriptableObject
    {
        public List<BaseCondition> DesiredConditions = new List<BaseCondition>();

        public bool IsFullfilled(Actor actor)
        {
            return !DesiredConditions.Any(c => !c.IsMet(actor));
        }
    }
}