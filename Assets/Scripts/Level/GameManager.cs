using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SunNum sunNum;
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
        sunNum.sunNum += changeNum;
        if (sunNum.sunNum <= 0) sunNum.sunNum = 0;
        UIManager.instance.UpdateUI();
    }
}
