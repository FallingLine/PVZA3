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
        void OnPeace();
        void OnShoot();
        void OnPF();
        void OnTaco();
        void OnTacoPF();
    }
    public class PlantFSM
    {
        public IState curState;
        public Dictionary<StateType, IState> states;

        public PlantFSM()
        {
            this.states = new Dictionary<StateType, IState>();
        }

        public void AddState(StateType stateType, IState state)
        {
            if (states.ContainsKey(stateType))
            {
                Debug.Log("[AddState] >>>>>>>>>>>Plant has contain key" + stateType);
                return;
            }
            states.Add(stateType, state);
        }

        public void SwitchState(StateType stateType)
        {

        }
    }
}