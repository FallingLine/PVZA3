using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class DemoPlant : MonoBehaviour
    {
        public string name;
        public int cost;
        public float HP;
        public float CD;
        public GameObject bullet;

        Plant demoPlant = new Plant();

        void Start()
        {
            demoPlant.name = name;
            demoPlant.cost = cost;
            demoPlant.HP = HP;
            demoPlant.CD = CD;
        }
        
        void Update()
        {
            
        }
    }