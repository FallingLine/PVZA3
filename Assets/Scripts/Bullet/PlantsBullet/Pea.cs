using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
//�ýű����ڼ���㶹�ӵ�����ʧ�������Լ��㶹�ӵ����ж��켣
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
