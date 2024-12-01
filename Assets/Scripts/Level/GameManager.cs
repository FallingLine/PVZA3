using PVZA3;
using PVZA3.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SunNum sunNum;
    public int zonNum;
    public bool gameStart = false;
    public LevelInfo levelInfo;
    public ZombieCreater zombieCreater;
    [NonSerialized] public float timer;

    void Awake()
    {
        instance = this;
        UIManager.instance.InitUI();
        GameObject obj = GameObject.Find("ZombieCreaters");
        zombieCreater = obj.GetComponent<ZombieCreater>();
        levelInfo = zombieCreater.levelInfo;
    }
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= WaveTime(levelInfo))
        {
            timer = 0;
            zombieCreater.wave += 1;
        }
    }
    public void ChangeSunNum(int changeNum)
    {
        sunNum.sunNum += changeNum;
        if (sunNum.sunNum <= 0) sunNum.sunNum = 0;
        UIManager.instance.UpdateUI();
    }
    public float WaveTime(LevelInfo tempLevelInfo)
    {
        if (tempLevelInfo.isHard == false)
        {
            return 20f;
        }
        else
        {
            return 10f;
        }
    }
}
