using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
/*************����ֲ��������****************/
public class DemoPlant : Plant
{
    public float attackSpeed;//����ٶ�
    public Transform mouth;//�ӵ�����λ��
    public PlantBullet bullet;//�ӵ�

    private float timer;         //�ӵ������ʱ��

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
    /*******************�����㶹****************************/
}