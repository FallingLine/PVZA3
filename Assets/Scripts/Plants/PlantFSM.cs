using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PVZA3.P_FSM
{
    public enum StateType
    {
        Peace,
        Shoot,
        PF,
        Taco,
        TacoPF,
    }
    public interface IState
    {
        void OnEnter();
        void OnExit();
        void OnUpdate();
        //void OnCleck();
        //void OnFixUpdate();
    }
    [Serializable]
    public class Blackboard
    {
        //此处存储共享数据，或者向外展示的数据，可配置数据
    }
    public class PlantFSM
    {
        public IState curState;
        public Dictionary<StateType, IState> states;
        public Blackboard blackboard;

        public PlantFSM(Blackboard blackboard)
        {
            this.states = new Dictionary<StateType, IState>();
            this.blackboard = blackboard;
        }

        public void AddState(StateType stateType, IState state)
        {
            if (states.ContainsKey(stateType))
            {
                Debug.Log("[AddState] >>>>>>>>>>> Plant has contain key : " + stateType);
                return;
            }
            states.Add(stateType, state);
        }

        public void SwitchState(StateType stateType)
        {
            if (!states.ContainsKey(stateType))
            {
                Debug.Log("[AddState] >>>>>>>>>>> Not contain key : " + stateType);
                return;
            }
            if (curState != null)
            {
                curState.OnExit();
            }
            curState = states[stateType];
            curState.OnEnter();
        }
        public void OnUpdate()
        {
            //curState.OnFixUpdate():
        }
        public void OnCheck()
        {
            //curState.OnCleck();
        }
    }
}