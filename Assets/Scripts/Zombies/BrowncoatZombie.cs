using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class BrowncoatZombie : MonoBehaviour
{
    public string zombieName;
    public float HP;
    public float ATK;
    public float moveSpeed;
    public float attackSpeed;
    public bool armorBool;
    public float armorHP;
    public float armorDR;
    public bool armorCanPenetrate;
    public float CSC;//综合强度系数

    public int cost;
    public float CD;

    IAZ browncoatZombie = new IAZ();

    void Awake()
    {
        browncoatZombie.name = zombieName;
        browncoatZombie.HP = HP;
        browncoatZombie.ATK = ATK;
        browncoatZombie.moveSpeed = moveSpeed;
        browncoatZombie.attackSpeed = attackSpeed;
        browncoatZombie.armorBool = armorBool;
        browncoatZombie.armorHP = armorHP;
        browncoatZombie.armorDR = armorDR;
        browncoatZombie.armorCanPenetrate = armorCanPenetrate;
        browncoatZombie.CSC = CSC;

        browncoatZombie.cost = cost;
        browncoatZombie.CD = CD;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
