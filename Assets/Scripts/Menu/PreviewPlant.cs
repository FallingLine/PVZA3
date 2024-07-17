using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PVZA3;
using TMPro;

public class PreviewPlant : MonoBehaviour
{
    [HideInInspector]
    public Plant plant;
    public GameObject preview;
    public TextMeshProUGUI needSun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Choose(Plant plant)
    {
        this.plant = plant;
        if (preview.transform.childCount >= 1)
        {
            Transform transform;
            for (int i = 0; i < preview.transform.childCount; i++)
            {
                transform = preview.transform.GetChild(i);
                GameObject.Destroy(transform.gameObject);
            }
        }
        GameObject a = Instantiate(plant.UIpreview,transform.position,Quaternion.identity);
        a.transform.parent = preview.transform;

        needSun.text = plant.cost.ToString();
    }
}
