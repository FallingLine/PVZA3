using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class Pea : MonoBehaviour
{
    public float damage;
    public float speed;
    public GameObject prefabPeaButtle;

    private Vector3 direction = new Vector3(1, 0, 0);

    PlantButtle peaButtle = new PlantButtle();
    
    void Start()
    {
        peaButtle.damage = damage;
        peaButtle.speed = speed;
    }


    void Update()
    {
        transform.position += direction * speed * Time.deltaTime * 10;
        if(transform.position.x > 20)
        {
            Destroy(prefabPeaButtle);
        }
    }
}
