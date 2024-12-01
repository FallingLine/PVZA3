using PVZA3;
using PVZA3.FSM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

[Serializable]
public class MouseBlackboard : Blackboard
{
    public float fPS = 60;
    public List<Texture2D> normal = new List<Texture2D>();
    public List<Texture2D> link = new List<Texture2D>();

    [NonSerialized] public int a = 0;//Í¼Æ¬ÐòÁÐ
}

public class MouseNormalState : IState
{
    private FSM fsm;
    private MouseBlackboard blackboard;
    private float timer;
    public MouseNormalState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as MouseBlackboard;
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
        timer += Time.deltaTime;
        if (timer >= 1f / blackboard.fPS)
        {
            timer = 0;
            if (blackboard.a < blackboard.normal.Count - 1)
            {
                blackboard.a++;
            }
            else
            {
                blackboard.a = 0;
            }
            Cursor.SetCursor(blackboard.normal[blackboard.a], Vector2.zero, CursorMode.Auto);
        }
    }
}

public class MouseLinkState : IState
{
    private FSM fsm;
    private MouseBlackboard blackboard;
    private float timer;
    public MouseLinkState(FSM fsm)
    {
        this.fsm = fsm;
        this.blackboard = fsm.blackboard as MouseBlackboard;
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
        timer += Time.deltaTime;
        if (timer >= 1f / blackboard.fPS)
        {
            timer = 0;
            if (blackboard.a < blackboard.normal.Count - 1)
            {
                blackboard.a++;
            }
            else
            {
                blackboard.a = 0;
            }
            Cursor.SetCursor(blackboard.link[blackboard.a], Vector2.zero, CursorMode.Auto);
        }
    }
}

public class CursorManager : MonoBehaviour
{
    private FSM fsm;
    public MouseBlackboard blackboard;
    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM(blackboard);
        fsm.AddState(StateType.a, new MouseNormalState(fsm));
        fsm.AddState(StateType.b, new MouseLinkState(fsm));
        fsm.SwitchState(StateType.a);
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        //fsm.OnCheck();
        fsm.OnUpdate();
    }
    void FixUpdate()
    {
        fsm.OnFixUpdate();
    }
}
