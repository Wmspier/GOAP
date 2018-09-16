using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace GOAP
{
    public class BaseAgent : MonoBehaviour, IAgent
    {
        private List<State> _states = new List<State>();
        private Dictionary<BaseResource, float> _resources = new Dictionary<BaseResource, float>();
        private List<IAction> _availableActions = new List<IAction>();

        public BaseResource GetResource<T>()
        {
            return _resources.FirstOrDefault(r => r.Key is T).Key;
        }

        public void ModifyResource<T>(float amount)
        {
            var resource = _resources.FirstOrDefault(r => r.Key is T).Key;
            if (resource)
                _resources[resource] += amount;
            else
                _resources.Add(resource, amount);
        }

        public bool HasState(string name)
        {
            return _states.FirstOrDefault(s => s.Name == name) != null;
        }

        private void Update()
        {
            //Perform Action
        }
    }
}
