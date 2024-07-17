using PVZA3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantCard : MonoBehaviour
{
    public Plant plant;
    public GameObject Card;
    public Image plantCard;
    void Update()
    {
        if (plant == null)
        {
            Card.SetActive(false);
        }
        else
        {
            Card.SetActive(true);
            plantCard.sprite = plant.cardPreview;
        }
    }
}
