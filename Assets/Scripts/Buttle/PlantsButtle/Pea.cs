using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
//该脚本用于检测豌豆子弹的消失条件，以及豌豆子弹的行动轨迹
public class Pea : MonoBehaviour
{
    public float damage;
    public float speed;

    private Vector3 direction = new Vector3(1, 0, 0);

    PlantButtle peaButtle = new PlantButtle();
    
    void Start()
    {
        peaButtle.damage = damage;
        peaButtle.speed = speed;
    }


    void Update()
    {
        transform.position += direction * peaButtle.speed * Time.deltaTime * 10;
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
