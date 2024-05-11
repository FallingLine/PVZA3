using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
/*************这一看就是豌豆射手的代码****************/
public class DemoPlant : MonoBehaviour
{
    public string plantName;    //植物名称
    public int cost;            //费用  
    public float HP;            //植物血量
    public float CD;            //种植CD
    public float attackSpeed;   //攻击速度
    public Transform mouth;
    public GameObject bullet;

    private float timer;         //子弹发射计时器

    ATKPlant demoPlant = new ATKPlant();  //ATKPlant是植物的数据库

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
    /*******************生成豌豆****************************/
}