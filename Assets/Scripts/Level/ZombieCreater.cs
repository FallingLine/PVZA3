using PVZA3;
using PVZA3.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieCreater : MonoBehaviour
{
    public LevelInfo levelInfo;
    public bool ifHalfWave = false;
    public Transform[] creater = new Transform[5];
    public int wave = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelInfo.zombies.Sort((a, b) => a.cSC.CompareTo(b.cSC));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreatZom(LevelInfo tempLevelInfo, bool tempifHalfWave, int tempWave)
    {
        if (tempifHalfWave == false)
        {
            if (tempWave == 0)
            {
                tempLevelInfo.willWave_1 = AddZombiePool(tempLevelInfo, tempLevelInfo.waveLevel[0]);
            }
            else
            {
                if (tempWave % 2 != 0 && wave <= tempLevelInfo.wave)
                {
                    tempLevelInfo.willWave_2 = AddZombiePool(tempLevelInfo, tempLevelInfo.waveLevel[tempWave]);
                }
                if (tempWave % 2 == 0 && wave <= tempLevelInfo.wave)
                {
                    tempLevelInfo.willWave_1 = AddZombiePool(tempLevelInfo, tempLevelInfo.waveLevel[tempWave]);
                }
            }
        }
        else
        {

        }
    }
    public List<Zombie> AddZombiePool(LevelInfo tempLevelInfo, float creatLevel)
    {
        List<Zombie> originZombies = tempLevelInfo.zombies;
        originZombies.Sort((a, b) => a.cSC.CompareTo(b.cSC));
        List <Zombie> tempZombies = new List<Zombie>();
        float tempLevel = creatLevel;
        int right = originZombies.Count - 1;
        for(; ; )
        {
            for (; right >= 0 && tempLevel < originZombies[right].cSC; ) { right--; }
            if (right < 0) { break; }
            int i = Random.Range(0, right + 1);
            tempZombies.Add(originZombies[i]);
            tempLevel -= originZombies[i].cSC;
        }
        for(int i =0; i<tempZombies.Count; i++)
        {
            Debug.Log(tempZombies[i].pvzName);
        }
        return tempZombies;
    }
    public void CreatZombies()
    {

    }
}
