using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelectInTime : MonoBehaviour
{
    public float showTime = 1f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= showTime)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
