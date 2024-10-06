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
    [NonSerialized] public bool detection;
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
        throw new NotImplementedException();
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
    private float line;
    public GameObject bottomLine;

    // Start is called before the first frame update
    void Start()
    {
        fsm = new PlantFSM(blackboard);
        fsm.AddState(StateType.Idle, new AI_IdleState(fsm));
        fsm.AddState(StateType.Attack, new AI_AttackState(fsm));
        fsm.SwitchState(StateType.Idle);

        bottomLine = GameObject.Find("BottomLine");
        line = (bottomLine.transform.position.x - transform.position.x) * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnCheck();
        fsm.OnUpdate();
        blackboard.detection = Physics2D.Raycast(transform.position, Vector3.right, line, 7);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + line, transform.position.y, transform.position.z), Color.red);
    }

    private void FixedUpdate()
    {
        fsm.OnFixUpdate();
    }
}
