using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class DemoZombie : Zombie
{
    private Vector3 direction = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= direction * moveSpeed * Time.deltaTime * 10;
    }
}
