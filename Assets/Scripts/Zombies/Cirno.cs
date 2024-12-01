using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
using PVZA3.FSM;
using System;
using DG.Tweening;

[Serializable]
public class CirnoBlackboard : Blackboard
{
    public Zombie zombie;
    public Animator zomAnim;
    public float disappearTime;
}

public class Cirno_MoveState : IState
{
    private FSM fsm;
    private CirnoBlackboard blackboard;
    public Cirno_MoveState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as CirnoBlackboard;
    }
    public void OnEnter()
    {
        blackboard.zomAnim.SetBool("HavePlant", false);
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
        if (blackboard.zombie.hP <= 0)
        {
            fsm.SwitchState(StateType.c);
        }
    }
}

public class Cirno_AttackState : IState
{
    private FSM fsm;
    private CirnoBlackboard blackboard;
    public Cirno_AttackState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as CirnoBlackboard;
    }
    public void OnEnter()
    {
        blackboard.zomAnim.SetBool("HavePlant", true);
    }
    public void OnExit()
    {
        //throw new NotImplementedException();
    }
    public void OnUpdate()
    {
        if (blackboard.zombie.plant == null)
        {
            fsm.SwitchState(StateType.a);
        }
        if (blackboard.zombie.hP <= 0)
        {
            fsm.SwitchState(StateType.c);
        }
    }
}
public class Cirno_DieState : IState
{
    private float timer;
    private FSM fsm;
    private CirnoBlackboard blackboard;
    public Cirno_DieState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as CirnoBlackboard;
    }
    public void OnEnter()
    {
        blackboard.zomAnim.SetBool("HPnull", true);
        timer = 0;
    }
    public void OnExit()
    {
        //throw new NotImplementedException();
    }
    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= blackboard.disappearTime)
        {
            GameObject.Destroy(blackboard.zombie.self);
        }
    }
}

public class Cirno : Zombie
{
    private FSM fsm;
    public CirnoBlackboard blackboard;

    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM(blackboard);
        fsm.AddState(StateType.a, new Cirno_MoveState(fsm));
        fsm.AddState(StateType.b, new Cirno_AttackState(fsm));
        fsm.AddState(StateType.c, new Cirno_DieState(fsm));
        fsm.SwitchState(StateType.a);
        brightness = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //fsm.OnCheck();
        fsm.OnUpdate();
        renderers.ForEach(SpriteRenderer => SpriteRenderer.material.SetFloat("_Brightness", brightness));
        if (hP <= 0)
        {
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
        }
        if (brightness <= 0f)
        {
            brightness = 0f;
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
