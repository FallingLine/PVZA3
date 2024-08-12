using PVZA3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class PlantCard : MonoBehaviour
{
    [NonSerialized] public Plant plant;
    public GameObject card;
    public Image plantCard;
    public TextMeshProUGUI needSun;
    void Update()
    {
        if (plant != null)
        {
            card.SetActive(true);
            plantCard.sprite = plant.cardPreview;
            needSun.text = plant.cost.ToString();
        }
        else
        {
            card.SetActive(false);
        }
    }
}
