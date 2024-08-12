using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PVZA3;

public class ChoosePlant : MonoBehaviour
{
    public CardSaver cardSaver;
    [NonSerialized]public GameObject mCardSaver;
    public CardBar cardBar;
    public PreviewPlant previewPlant;
    public GameObject join;
    public GameObject unJoin;

    // Start is called before the first frame update
    void Start()
    {
        mCardSaver = GameObject.Find("CardSaver");
        cardSaver = mCardSaver.GetComponent<CardSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (previewPlant.plant != null)
        {
            if (previewPlant.plant.isChoosed == true)
            {
                join.SetActive(false);
                unJoin.SetActive(true);
            }
            else
            {
                join.SetActive(true);
                unJoin.SetActive(false);
            }
        }
    }
    public void Join()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (cardSaver.plants[i] == null)
            {
                cardSaver.plants[i] = previewPlant.plant;
                previewPlant.plant.isChoosed = true;
                break;
            }
        }
        for (int i = 0; i <= 5; i++)
        {
            cardBar.plantCards[i].plant = cardSaver.plants[i];
        }
    }
    public void UnJoin()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (cardSaver.plants[i] == previewPlant.plant)
            {
                cardSaver.plants[i] = null;
                previewPlant.plant.isChoosed = false;
                break;
            }
        }
        for (int i = 0; i <= 5; i++)
        {
            cardBar.plantCards[i].plant = null;
        }
    }
}
