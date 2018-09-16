using UnityEngine;
namespace GOAP
{
    [CreateAssetMenu(fileName = "NewResource", menuName = "GOAP/Resource", order = 0)]
    public class BaseResource : ScriptableObject
    {
        public string Name = "Resource";
    }
}