using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class DemoPlant : MonoBehaviour
{
    public string plantName;
    public int cost;
    public float HP;
    public float CD;
    public float attackSpeed;
    public Transform mouth;
    public GameObject bullet;

    private float timer;

    ATKPlant demoPlant = new ATKPlant();

    void Awake()
    {
        demoPlant.name = plantName;
        demoPlant.cost = cost;
        demoPlant.HP = HP;
        demoPlant.CD = CD;
        demoPlant.attackSpeed = attackSpeed;
    }

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= demoPlant.attackSpeed)
        {
            timer = 0;
            Instantiate(bullet, mouth.position, Quaternion.identity);
        }
    }
}