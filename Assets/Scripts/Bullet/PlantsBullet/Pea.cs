using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
//该脚本用于检测豌豆子弹的消失条件，以及豌豆子弹的行动轨迹
public class Pea : Bullet
{
    private Vector3 direction = new Vector3(1, 0, 0);
    
    void Start()
    {
    }


    void Update()
    {
        transform.position += direction * speed * Time.deltaTime * 10;
        if(transform.position.x > 20)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            GameObject.Destroy(gameObject);
            
        }
    }
}
