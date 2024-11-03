using PVZA3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieMove : MonoBehaviour
{
    public float animSpeed;
    public bool attack;
    public Zombie zombie;
    [NonSerialized] public float n = 0;
    // Start is called before the first frame update
    void Start()
    {
        zombie = this.GetComponent<Zombie>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.right * n * Time.deltaTime;
    }
    public void WalkSpeedChange(float speed)
    {
        n = speed * animSpeed;
    }
    public void StopMove()
    {
        n = 0;
    }
    public void Attack()
    {
        if (zombie.plant != null)
        {
            zombie.plant.hP -= zombie.aTK;
        }
    }
}
