using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class PeaShooter : MonoBehaviour
{
    public string plantName;    //植物名称
    public int cost;            //费用  
    public float HP;            //植物血量
    public float CD;            //种植CD
    public float attackSpeed;   //攻击速度

    private float timer;        //未知

    ATKPlant peaShooter = new ATKPlant();
    void Awake()
    {
        peaShooter.name = plantName;
        peaShooter.cost = cost;
        peaShooter.HP = HP;
        peaShooter.CD = CD;
        peaShooter.attackSpeed = attackSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {

    }

    public void pf()
    {

    }

    public void taco()
    {

    }
}