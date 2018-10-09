using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using UnityEngine;
namespace GOAP
{
    //  TODO aherrera : to be moved into it's own file
    public struct SubjectData
    {
        public List<State> States;
        public Dictionary<BaseResource, float> Resources;
    }

    public class BaseSubject : MonoBehaviour, ISubject
    {
        public List<IAction> AllowableActions = new List<IAction>();

        public SubjectData Data;

        private void Awake()
        {
            Data = new SubjectData()
            {
                States = new List<State>(),
                Resources = new Dictionary<BaseResource, float>()
            };
        }

        public float GetResource(Type resourceType)
        {
            return Data.Resources.FirstOrDefault(r => r.Key.GetType() == resourceType).Value;
        }

        public void ModifyResource(Type resourceType, float amount)
        {
            var resource = Data.Resources.FirstOrDefault(r => r.Key.GetType() == resourceType).Key;
            if (resource)
                Data.Resources[resource] += amount;
            else
                Data.Resources.Add(resource, amount);
        }

        public bool HasState(State state)
        {
            return Data.States.FirstOrDefault(s => s.GetType() == state.GetType()) != null;
        }

        public void ModifyState(State state, StateChange stateChange)
        {
            if (stateChange == StateChange.Gain && Data.States.FirstOrDefault(s => s.GetType() == state.GetType()) == null)
                Data.States.Add(state);
            else if(stateChange == StateChange.Lose)
            {
                Data.States.Remove(Data.States.FirstOrDefault(s => s.GetType() == state.GetType()));
            }     
        }
    }
}
