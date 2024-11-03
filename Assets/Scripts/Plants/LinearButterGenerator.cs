using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LinearButterGenerator : MonoBehaviour
{
    public Transform bulletPos;
    public ObjectPool objectPool;
    public GameObject obj;
    public string poolName;

    void Awake()
    {
        obj = GameObject.Find(poolName);
        objectPool = obj.GetComponent<ObjectPool>();
    }
    void Shoot()
    {
        GameObject temp = objectPool.pool.Get();
        temp.transform.position = bulletPos.position;
    }
}