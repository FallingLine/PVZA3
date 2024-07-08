using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PVZA3
{
    public class Plant : MonoBehaviour
    {
        public string name;
        public int cost;
        public float HP;
        public float CD;
        public bool isTaco;
        public bool canSpeedUp = true;
    }
    public class Zombie : MonoBehaviour
    {
        public string name;
        public float HP;
        public float ATK;
        public float moveSpeed;
        public float attackSpeed;
        public bool armorBool;
        public float armorHP;
        public float armorDR;
        public bool armorCanPenetrate;
        public float CSC;//综合强度系数
    }
    public class IAZ : Zombie
    {
        public int cost;
        public float CD;
    }
    public class Bullet : MonoBehaviour
    {
        public float damage;
        public float speed;
    }
    public class PlantBullet : Bullet
    {
        
    }
    public class Zombiebullet : Bullet
    {

    }
    public class SunFlower : MonoBehaviour
    {
        public float spawnSpeed;
        public int onceGet;
    }
}