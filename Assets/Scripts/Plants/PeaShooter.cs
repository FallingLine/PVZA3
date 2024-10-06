using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
using PVZA3.P_FSM;

[Serializable]
public class PlantsBlackboard : Blackboard
{
    public Animator plantAnim;
    public Collider2D detection;
}

public class AI_IdleState : IState
{
    private PlantFSM fsm;
    private PlantsBlackboard blackboard;
    public AI_IdleState(PlantFSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as PlantsBlackboard;
    }
    public void OnEnter()
    {
        blackboard.plantAnim.Play("idle");
    }
    public void OnExit()
    {
        throw new NotImplementedException();
    }
    public void OnUpdate()
    {
        var tag = blackboard.detection.tag;
        Debug.Log(tag);
        if (tag == "Zombie")
        {
            this.fsm.SwitchState(StateType.Attack);
        }
    }
}

public class AI_AttackState : IState
{
    private PlantFSM fsm;
    private PlantsBlackboard blackboard;
    public AI_AttackState(PlantFSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as PlantsBlackboard;
    }
    public void OnEnter()
    {
        blackboard.plantAnim.Play("attack");
    }
    public void OnExit()
    {
        throw new NotImplementedException();
    }
    public void OnUpdate()
    {
        throw new NotImplementedException();
    }
}

public class PeaShooter : Plant
{
    public Animator plantAnim;
    private PlantFSM fsm;
    public PlantsBlackboard blackboard;


    // Start is called before the first frame update
    void Start()
    {
        fsm = new PlantFSM(blackboard);
        fsm.AddState(StateType.Idle, new AI_IdleState(fsm));
        fsm.AddState(StateType.Attack, new AI_AttackState(fsm));
        fsm.SwitchState(StateType.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnCheck();
        fsm.OnUpdate();
    }

    private void FixedUpdate()
    {
        fsm.OnFixUpdate();
    }
}
