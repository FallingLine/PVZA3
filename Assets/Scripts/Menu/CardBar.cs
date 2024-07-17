using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class CardBar : MonoBehaviour
{
    public static Plant[] plants = new Plant[6];
    public PlantCard[] plantCards = new PlantCard[6];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RePick()
    {
        for (int i = 0; i <= 5; i++)
        {
            plants[i] = null;
        }
        for (int i = 0; i <= 5; i++)
        {
            plantCards[i].plant = plants[i];
        }
    }
}
