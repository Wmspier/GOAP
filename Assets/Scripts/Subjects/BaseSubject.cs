using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
namespace GOAP
{
    public class BaseSubject : MonoBehaviour, ISubject
    {
        public List<IAction> AllowableActions = new List<IAction>();

        private List<State> _states = new List<State>();
        private Dictionary<BaseResource, float> _resources = new Dictionary<BaseResource, float>();

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

        public bool HasState(State state)
        {
            return _states.FirstOrDefault(s => s.GetType() == state.GetType()) != null;
        }

        public void ModifyState(State state, StateChange stateChange)
        {
            if (stateChange == StateChange.Gain && _states.FirstOrDefault(s => s.GetType() == state.GetType()) == null)
                _states.Add(state);
            else if(stateChange == StateChange.Lose)
            {
                _states.Remove(_states.FirstOrDefault(s => s.GetType() == state.GetType()));
            }     
        }
    }
}
