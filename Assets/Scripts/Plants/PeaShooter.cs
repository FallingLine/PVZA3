using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
using PVZA3.FSM;

[Serializable]
public class PeaShooterBlackboard : Blackboard
{
    public float waitTime;
    public Animator plantAnim;
    public PlantDetection plantDetection;
}

public class PeaShooter_IdleState : IState
{
    private float timer;

    private FSM fsm;
    private PeaShooterBlackboard blackboard;
    public PeaShooter_IdleState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as PeaShooterBlackboard;
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
        if (blackboard.plantDetection.haveZombie == true)
        {
            fsm.SwitchState(StateType.b);
            Debug.Log("There have Zombies");
        }
    }
}

public class PeaShooter_AttackState : IState
{
    private float timer;
    private FSM fsm;
    private PeaShooterBlackboard blackboard;
    public PeaShooter_AttackState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as PeaShooterBlackboard;
    }
    public void OnEnter()
    {
        timer = 0;
        blackboard.plantAnim.SetTrigger("HaveZombie");
    }
    public void OnExit()
    {
        //throw new NotImplementedException();
    }
    public void OnUpdate()
    {
        timer += Time.deltaTime;
        AnimationClip animationClip = blackboard.plantAnim.runtimeAnimatorController.animationClips[1];
        float length = animationClip.length;
        if (timer >= length/2+blackboard.waitTime)
        {
            timer = 0;
            blackboard.plantAnim.SetTrigger("HaveZombie");
        }
        if (blackboard.plantDetection.haveZombie == false)
        {
            fsm.SwitchState(StateType.a);
            Debug.Log("Zombies Dead");
        }
    }
}

public class PeaShooter : Plant
{
    public GameObject deadAction;

    private FSM fsm;
    public PeaShooterBlackboard blackboard;

    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM(blackboard);
        fsm.AddState(StateType.a, new PeaShooter_IdleState(fsm));
        fsm.AddState(StateType.b, new PeaShooter_AttackState(fsm));
        fsm.SwitchState(StateType.a);
        hP = fullHP;
    }

    // Update is called once per frame
    void Update()
    {
        //fsm.OnCheck();
        fsm.OnUpdate();
        if (hP <= 0)
        {
            GameObject.Destroy(self);
            if (deadAction != null)
            {
                Instantiate(deadAction, this.transform.position, Quaternion.identity);
            }
        }
    }
    void FixUpdate()
    {
        fsm.OnFixUpdate();
    }
}
