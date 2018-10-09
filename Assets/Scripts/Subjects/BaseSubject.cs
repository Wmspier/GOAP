using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
namespace GOAP
{
    //  TODO aherrera : to be moved into it's own file
    [Serializable]
    public struct SubjectData
    {
        public List<State> States;
        public Dictionary<string, float> Resources;
    }

    public class BaseSubject : MonoBehaviour, ISubject
    {
        public List<BaseAction> AllowableActions = new List<BaseAction>();

        public SubjectData Data;

        public BaseSubject()
        {
            Data = new SubjectData()
            {
                States = new List<State>(),
                Resources = new Dictionary<string, float>()
            };
        }

        public float GetResource(string resourceType)
        {
            var resource = Data.Resources.FirstOrDefault(r => r.Key == resourceType);
            return resource.Value;
        }

        public void ModifyResource(string resourceType, float amount)
        {
            if (Data.Resources.ContainsKey(resourceType))
                Data.Resources[resourceType] += amount;
            else
                Data.Resources.Add(resourceType, amount);
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
