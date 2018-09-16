using UnityEngine;
namespace GOAP
{
    [CreateAssetMenu(fileName = "NewState", menuName = "GOAP/State", order = 2)]
    public class State : ScriptableObject
    {
        public string Name;
    }
}
