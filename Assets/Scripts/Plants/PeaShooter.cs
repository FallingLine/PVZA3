using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
using PVZA3.P_FSM;

[Serializable]
public class PlantsBlackboard : Blackboard
{

}

public class PeaShooter : Plant
{
    private PlantFSM fsm;
    public PlantsBlackboard blackboard;

    private void Awake()
    {
        fsm = new PlantFSM(blackboard);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
