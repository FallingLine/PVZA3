using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class DemoPlant : MonoBehaviour
    {
        public string plantName;
        public int cost;
        public float HP;
        public float CD;
        public GameObject bullet;

        ATKPlant demoPlant = new ATKPlant();

        void Start()
        {
            demoPlant.name = plantName;
            demoPlant.cost = cost;
            demoPlant.HP = HP;
            demoPlant.CD = CD;
        }
        
        void Update()
        {
            
        }
    }