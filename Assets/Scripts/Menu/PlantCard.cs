using PVZA3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantCard : MonoBehaviour
{
    public Plant plant;
    public GameObject Card;
    public Image plantCard;
    public TextMeshProUGUI needSun;
    void Update()
    {
        if (plant != null)
        {
            Card.SetActive(true);
            plantCard.sprite = plant.cardPreview;
            needSun.text = plant.cost.ToString();
        }
        else
        {
            Card.SetActive(false);
        }
    }
}
