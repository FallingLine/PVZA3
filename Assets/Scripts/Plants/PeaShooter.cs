using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public enum StateType
{
    Peace,
    Shoot,
    PF,
    Taco,
    TacoPF,
}
public class PeaShooter : Plant
{
    private StateType cueState;

    private float timer;        //δ֪
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        cueState = StateType.Peace;
    }

    // Update is called once per frame
    void Update()
    {
        switch (cueState)
        {
            case StateType.Peace:
                OnPeace();
                break;
            case StateType.Shoot:
                OnShoot();
                break;
            case StateType.PF:
                OnPF();
                break;
            case StateType.Taco:
                OnTaco();
                break;
            case StateType.TacoPF:
                OnTacoPF();
                break;
            default:
                break;
        }
    }

    public void OnPeace()
    {

    }

    public void OnShoot()
    {

    }

    public void OnPF()
    {

    }
    public void OnTaco()
    {

    }
    public void OnTacoPF()
    {

    }
}