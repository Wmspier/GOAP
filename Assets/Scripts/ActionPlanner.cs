﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace GOAP
{
    public static class ActionPlanner
    {        
        private class PlannerNode
        {
            public PlannerNode Parent;
            public float RunningCost;
            public SubjectData RunningData;
            public BaseAction Action;

            public PlannerNode()
            {

            }

            public PlannerNode(PlannerNode copyOf)
            {
                Parent = copyOf.Parent;
                RunningCost = copyOf.RunningCost;
                RunningData = copyOf.RunningData;
                Action = copyOf.Action;
            }
        }

        public static Stack<BaseAction> ConstructActionPlan(Actor actor, Goal goal, List<BaseAction> performableActions)
        {
            List<PlannerNode> treeGraph = new List<PlannerNode>();

            PlannerNode start = new PlannerNode()
            {
                RunningData = actor.Data
            };

            bool success = BuildGraph(start, treeGraph, goal, performableActions);

            if(!success)
            {
                //  Plan was not created -- sad.
                UnityEngine.Debug.Log("Plan failed");
                return new Stack<BaseAction>();
            }

            PlannerNode cheapest = null;
            foreach(var rootNode in treeGraph)
            {
                if(cheapest == null)
                {
                    cheapest = rootNode;
                }
                else
                {
                    if(rootNode.RunningCost < cheapest.RunningCost)
                    {
                        cheapest = rootNode;
                    }
                }
            }

            //  Get the cheapest node and work back through parents to construct action plan
            var actionPlan = new Stack<BaseAction>();
            PlannerNode n = cheapest;
            while(n != null)
            {
                if(n.Action != null)
                {
                    actionPlan.Push(n.Action);
                }
                n = n.Parent;
            }

            //Debug
            var debugString = "I made a plan! ";
            foreach(var action in actionPlan)
            {
                debugString += action.name + " - ";
            }
            UnityEngine.Debug.Log(debugString);

            return actionPlan;
        }

        /// <summary>
        /// Based on the given parent, we construct a graph branching from it.
        /// Returns true if ANY plan was found.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="graphRef"></param>
        /// <param name="goal"></param>
        /// <param name="performableActions"></param>
        /// <returns></returns>
        private static bool BuildGraph(PlannerNode parent, List<PlannerNode> graphRef, Goal goal, List<BaseAction> performableActions)
        {
            bool planFound = false;
            
            foreach(var action in performableActions)
            {
                PlannerNode actualBatman = new PlannerNode(parent);

                if (IsConditionsMet(action.Conditions, actualBatman.RunningData))
                {
                    //  Apply the results of the action as if completed successfully.
                    SubjectData resultantData = CopyActionResults(actualBatman.RunningData, action.Results);
                    PlannerNode node = new PlannerNode()
                    {
                        Parent = actualBatman,
                        RunningCost = actualBatman.RunningCost + (int)action.Difficulty,
                        RunningData = resultantData,
                        Action = action
                    };

                    if(IsConditionsMet(goal.DesiredConditions, resultantData))
                    {
                        //  A solution has been constructed;
                        graphRef.Add(node);
                        planFound = true;
                    }
                    else
                    {
                        //  Solution not yet found, test remaining actions
                        List<BaseAction> subsetActions = CreateActionSubset(performableActions, action);
                        planFound = BuildGraph(node, graphRef, goal, subsetActions);
                    }
                }
            }

            return planFound;
        }

        /// <summary>
        /// Test if given conditions are met based on given data.
        /// </summary>
        /// <param name="toTest"></param>
        /// <param name="currentData"></param>
        /// <returns></returns>
        private static bool IsConditionsMet(List<BaseCondition> toTest, SubjectData currentData)
        {
            bool allMet = true;// toTest.Count > 0;

            foreach(var condition in toTest)
            {
                allMet &= condition.IsMet(currentData);
            }

            return allMet;
        }

        /// <summary>
        /// Copy the results of the action to simulate plan flow
        /// </summary>
        /// <param name="runningData"></param>
        /// <param name="actionResults"></param>
        /// <returns></returns>
        private static SubjectData CopyActionResults(SubjectData runningData, List<BaseResult> actionResults)
        {
            var newData = new SubjectData()
            {
                Resources = new Dictionary<string, float>(runningData.Resources),
                States = new List<State>(runningData.States)
            };

            var subjectDummyData = new SubjectData();

            foreach (var result in actionResults)
            {
                //  TODO aherrera : we should be able to apply results onto a subject -- but not necessary
                result.Apply(ref newData, ref subjectDummyData);
            }

            return newData;
        }

        /// <summary>
        /// Create a new subset of actions that does not contain the already performed action.
        /// </summary>
        /// <param name="performableActions"></param>
        /// <param name="performedAction"></param>
        /// <returns></returns>
        private static List<BaseAction> CreateActionSubset(List<BaseAction> performableActions, BaseAction performedAction)
        {
            List<BaseAction> actionSubset = new List<BaseAction>();
            foreach(var action in performableActions)
            {
                if(!action.Equals(performedAction))
                {
                    actionSubset.Add(action);
                }
            }
            return actionSubset;
        }
    }
}
