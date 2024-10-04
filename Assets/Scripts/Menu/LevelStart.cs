using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using PVZA3;
using PVZA3.UI;

public class LevelStart : SceneLoader
{
    public CardSaver cardSaver;
    [NonSerialized] public GameObject mCardSaver;
    public GameObject buttonDark;
    public GameObject buttonLight;
    public GameObject text;

    [NonSerialized] public int sceneID;
    [NonSerialized] public Scene scene;

    public LevelInfo levelNeedLoad;
    // Start is called before the first frame update
    void Start()
    {
        mCardSaver = GameObject.Find("CardSaver");
        cardSaver = mCardSaver.GetComponent<CardSaver>();
        scene = levelNeedLoad.scene;
    }

    // Update is called once per frame
    void Update()
    {
        if(cardSaver.plants.Length >= 3)
        {
            buttonDark.SetActive(false);
            buttonLight.SetActive(true);
        }
        else
        {
            buttonDark.SetActive(true);
            buttonLight.SetActive(false);
        }
        sceneID = (int)scene + 1;
    }

    public void Rock()
    {
        LoadScene(sceneID, text);
    }
}
