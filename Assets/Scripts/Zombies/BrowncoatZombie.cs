using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
using PVZA3.FSM;
using System;
using DG.Tweening;

[Serializable]
public class NormalZombieBlackboard : Blackboard
{
    public Zombie zombie;
    public Animator zomAnim;
}

public class NormalZombie_MoveState : IState
{
    private FSM fsm;
    private NormalZombieBlackboard blackboard;
    public NormalZombie_MoveState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as NormalZombieBlackboard;
    }
    public void OnEnter()
    {
        //throw new NotImplementedException();
    }
    public void OnExit()
    {
        //throw new NotImplementedException();
    }
    public void OnUpdate()
    {
        if (blackboard.zombie.plant != null)
        {
            fsm.SwitchState(StateType.b);
        }
    }
}

public class NormalZombie_AttackState : IState
{
    private FSM fsm;
    private NormalZombieBlackboard blackboard;
    public NormalZombie_AttackState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as NormalZombieBlackboard;
    }
    public void OnEnter()
    {
        
    }
    public void OnExit()
    {
        //throw new NotImplementedException();
    }
    public void OnUpdate()
    {
        blackboard.zomAnim.SetTrigger("HavePlant");
        if (blackboard.zombie.plant == null)
        {
            fsm.SwitchState(StateType.a);
        }
    }
}
public class NormalZombie_DieState : IState
{
    private float timer;
    private FSM fsm;
    private NormalZombieBlackboard blackboard;
    public NormalZombie_DieState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as NormalZombieBlackboard;
    }
    public void OnEnter()
    {
        
    }
    public void OnExit()
    {
        //throw new NotImplementedException();
    }
    public void OnUpdate()
    {

    }
}
public class BrowncoatZombie : Zombie
{
    private FSM fsm;
    public NormalZombieBlackboard blackboard;
    
    void Start()
    {
        fsm = new FSM(blackboard);
        fsm.AddState(StateType.a, new NormalZombie_MoveState(fsm));
        fsm.AddState(StateType.b, new NormalZombie_AttackState(fsm));
        fsm.AddState(StateType.c, new NormalZombie_DieState(fsm));
        fsm.SwitchState(StateType.a);
        brightness = 1f;
    }
    void Update()
    {
        //fsm.OnCheck();
        fsm.OnUpdate();
        renderers.ForEach(SpriteRenderer => SpriteRenderer.material.SetFloat("_Brightness", brightness));
        if (hP <= fullHP / 2)
        {
            HalfBloodAction();
        }
        if (brightness <= 1f)
        {
            brightness = 1f;
        }
        else
        {
            brightness -= Time.deltaTime;
        }
    }
    void FixUpdate()
    {
        fsm.OnFixUpdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.collider.tag;
        if (tag == "Plant")
        {
            Plant tempPlant = collision.gameObject.GetComponent<Plant>();
            if (tempPlant.faction != faction)
            {
                plant = tempPlant;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        var tag = collision.collider.tag;
        if (tag == "Plant")
        {
            Plant tempPlant = collision.gameObject.GetComponent<Plant>();
            if (tempPlant.faction != faction)
            {
                plant = null;
            }
        }
    }
}
