using PVZA3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public GameObject pvzObject;
    public int defaultCapacity = 10;
    public int maxSize = 114;

    public int countAll;
    public int countActive;
    public int countInactive;

    public ObjectPool<GameObject> pool;
    void Start()
    {
        pool = new ObjectPool<GameObject>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy, true, defaultCapacity, maxSize);
    }
    void Update()
    {
        countAll = pool.CountAll;
        countActive = pool.CountActive;
        countInactive = pool.CountInactive;
    }
    GameObject CreateFunc()
    {
        var obj = Instantiate(pvzObject);
        obj.GetComponent<Bullet>().pool = pool;
        return obj;
    }
    void ActionOnGet(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }
    void ActionOnRelease(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }
    void ActionOnDestroy(GameObject obj)
    {
        Destroy(obj);
    }
}