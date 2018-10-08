﻿using System.Collections.Generic;
using UnityEngine;
namespace GOAP
{
    public class Actor : BaseSubject, IActor
    {
        public Goal Goal;

        private Stack<IAction> _actions = new Stack<IAction>();
        private IAction _currentAction;

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
                if(topAction.Enter() == false)
                {
                    PlanActions();
                }
                _currentAction = topAction;
            }
            else
            {
                if(_currentAction.Perform() == false)
                {
                    PlanActions();
                }
            }

            if(_currentAction.IsComplete())
            {
                _currentAction.Exit();
                _currentAction = null;
                _actions.Pop();
            }
        }

        private void PlanActions()
        {
            _actions.Clear();
            _actions = ActionPlanner.ConstructActionPlan(Goal);
        }
    }
}