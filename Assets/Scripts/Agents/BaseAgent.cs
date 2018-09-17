using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
namespace GOAP
{
    public class BaseAgent : MonoBehaviour, IAgent
    {
        private List<State> _states = new List<State>();
        private Dictionary<BaseResource, float> _resources = new Dictionary<BaseResource, float>();
        private List<IAction> _availableActions = new List<IAction>();

        public float GetResource(Type resourceType)
        {
            return _resources.FirstOrDefault(r => r.Key.GetType() == resourceType).Value;
        }

        public void ModifyResource(Type resourceType, float amount)
        {
            var resource = _resources.FirstOrDefault(r => r.Key.GetType() == resourceType).Key;
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
