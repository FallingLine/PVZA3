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
    public float interval;
    public Transform mouth;
    public GameObject bullet;

    private float timer;

    Plant demoPlant = new Plant();

    void Start()
    {
        demoPlant.name = plantName;
        demoPlant.cost = cost;
        demoPlant.HP = HP;
        demoPlant.CD = CD;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            timer = 0;
            Instantiate(bullet, mouth.position, Quaternion.identity);
        }
    }
}