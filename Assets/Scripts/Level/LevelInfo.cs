using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;
using System;

[CreateAssetMenu(fileName ="LevelInfo",menuName = "EditorAsset/¹Ø¿¨ÐÅÏ¢")]
public class LevelInfo : ScriptableObject
{
    public string levelName;
    public bool isBoss = false;
    public int wave;
    public List<int> importantWave = new List<int>();
    public int wave_2;
    public List<int> importantWave_2 = new List<int>();
    public List<Zombie> zombies = new List<Zombie>();
    public Scene scene;
    public GameMod gameMod;

    [NonSerialized] public int sunNum = 3;

    public Dictionary<Zombie, int> willWave_1 = new Dictionary<Zombie, int>();
    public Dictionary<Zombie, int> willWave_2 = new Dictionary<Zombie, int>();

    public List<Vector2Int> water = new List<Vector2Int>();
    public List<Vector2Int> earth = new List<Vector2Int>();
}
