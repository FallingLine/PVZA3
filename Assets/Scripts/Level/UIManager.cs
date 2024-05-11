using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI sunNumText;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitUI()
    {
        sunNumText.text = GameManager.instance.sunNum.ToString();
    }
    public void UpdateUI()
    {
        sunNumText.text = GameManager.instance.sunNum.ToString();
    }
    /********************更新向日葵在UI上的表示数量**********************/
}
