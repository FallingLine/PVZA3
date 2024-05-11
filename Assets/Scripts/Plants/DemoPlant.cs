using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
/*************��һ�������㶹���ֵĴ���****************/
public class DemoPlant : MonoBehaviour
{
    public string plantName;    //ֲ������
    public int cost;            //����  
    public float HP;            //ֲ��Ѫ��
    public float CD;            //��ֲCD
    public float attackSpeed;   //�����ٶ�
    public Transform mouth;
    public GameObject bullet;

    private float timer;         //�ӵ������ʱ��

    ATKPlant demoPlant = new ATKPlant();  //ATKPlant��ֲ������ݿ�

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
    /*******************�����㶹****************************/
}