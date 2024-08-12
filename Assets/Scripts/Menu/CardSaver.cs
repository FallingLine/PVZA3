using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class CardSaver : MonoBehaviour
{
    [HideInInspector]
    public Plant[] plants = new Plant[6];
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
