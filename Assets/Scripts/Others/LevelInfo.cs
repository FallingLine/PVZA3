using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PVZA3.Level
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "EditorAsset/¹Ø¿¨ÐÅÏ¢")]
    public class LevelInfo : ScriptableObject
    {
        public string levelName;
        public bool isBoss = false;
        public bool isHard = false;
        public int wave;
        public List<float> waveLevel = new List<float>();
        public List<int> importantWave = new List<int>();
        public int wave_2;
        public List<float> waveLevel_2 = new List<float>();
        public List<int> importantWave_2 = new List<int>();
        public List<Zombie> zombies = new List<Zombie>();
        public Scene scene;
        public GameMod gameMod;

        [NonSerialized] public int sunNum = 3;

        public List<Zombie> willWave_1 = new List<Zombie>();
        public List<Zombie> willWave_2 = new List<Zombie>();

        public List<Vector2Int> water = new List<Vector2Int>();
        public List<Vector2Int> earth = new List<Vector2Int>();
    }

}