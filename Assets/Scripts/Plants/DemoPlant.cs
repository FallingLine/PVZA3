using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
/*************测试植物主程序****************/
public class DemoPlant : Plant
{
    public float attackSpeed;//射击速度
    public Transform mouth;//子弹生成位置
    public PlantBullet bullet;//子弹

    private float timer;         //子弹发射计时器

    void Awake()
    {
    }

    void Start()
    {
        
    }

    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            timer = 0;
            Instantiate(bullet, mouth.position, Quaternion.identity);
        }
    }
    /*******************生成豌豆****************************/
}