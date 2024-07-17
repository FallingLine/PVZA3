using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class ChoosePlant : MonoBehaviour
{
    public PreviewPlant previewPlant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Join()
    {
        int n = 0;
        while (CardBar.plants[n] != null)
        {
            n++;
            if (n >= 6 || n < 0)
            {
                n = 1;
                Debug.Log("Full");
                break;
            }
        }
        CardBar.plants[n] = previewPlant.plant;
    }
}
