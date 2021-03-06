﻿using System.Collections.Generic;
using UnityEngine;
namespace GOAP
{
    public class Actor : BaseSubject, IActor
    {
        public Goal Goal;

        private Stack<BaseAction> _actions;
        private BaseAction _currentAction;

        private void Awake()
        {
            _actions = new Stack<BaseAction>();
        }

        public void Update()
        {
            if(Goal.IsFullfilled(this))
            {
                Debug.LogError("My Life is Over");
                return;
            }
            if(_actions.Count > 0)
            {
                PerformCurrentAction();
            }
            else
            {
                PlanActions();
            }
        }

        public void PerformCurrentAction()
        {
            var topAction = _actions.Peek();
            if(topAction != _currentAction)
            {
                Debug.Log("New action to do : " + topAction.name);
                if(topAction.Enter(this) == false)
                {
                    Debug.Log("Can't do topAction : " + topAction.name);
                    PlanActions();
                }
                _currentAction = topAction;
            }
            else
            {
                if(_currentAction.Perform(this) == false)
                {
                    Debug.Log("Failed performance of action : " + _currentAction.name);
                    PlanActions();
                }
            }

            if(_currentAction.IsComplete())
            {
                Debug.Log("I did it -- " + _currentAction.name);
                _currentAction.Exit(this);
                _currentAction = null;
                _actions.Pop();
            }
        }

        private void PlanActions()
        {
            _actions.Clear();
            var worldActions = GetWorldActions();
            _actions = ActionPlanner.ConstructActionPlan(this, Goal, worldActions);
        }

        private List<BaseAction> GetWorldActions()
        {
            var subjects = FindObjectsOfType<BaseSubject>();
            var allActions = new List<BaseAction>();
            foreach(var subject in subjects)
            {
                foreach(var allowabledAction in subject.AllowableActions)
                {
                    if(!allActions.Contains(allowabledAction))
                    {
                        allActions.Add(allowabledAction);
                    }
                }
            }
            //  Get objects of Type SUBJECT
            //  Get their ALLOWABLE actions

            return allActions;
        }
    }
}
