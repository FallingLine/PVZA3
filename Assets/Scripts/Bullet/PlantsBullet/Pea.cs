using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
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
            pool.Release(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.collider.tag;
        if (tag == "Zombie")
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            zombie.hP -= damage;
            zombie.brightness = 1.25f;
            pool.Release(gameObject);
        }
    }
}
