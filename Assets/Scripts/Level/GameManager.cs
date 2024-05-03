using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int sunNum;
    void Awake()
    {
        instance = this;
        UIManager.instance.InitUI();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ChangeSunNum(int changeNum)
    {
        sunNum += changeNum;
        if (sunNum <= 0) sunNum = 0;
        UIManager.instance.UpdateUI();
    }
}
