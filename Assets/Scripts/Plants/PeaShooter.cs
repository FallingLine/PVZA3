using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class PeaShooter : MonoBehaviour
{
    public string plantName;
    public int cost;
    public float HP;
    public float CD;
    public float attackSpeed;

    private float timer;

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