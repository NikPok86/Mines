using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject moneyPanel;
    public Text moneyText;
    public Text codeText;
    public int moneyValue = 0;

    void Start()
    {
        
    }

    void Update()
    {
        moneyText.text = "Money: " + moneyValue;
    }

    public void AddMoney()
    {
        if (!canvas.GetComponent<CanvasScript>().isInGame)
        {
            moneyPanel.SetActive(true);
        }
    }

    public void Confirm()
    {
        if(codeText.text == "123")
        {
            moneyValue += 10;
            moneyText.text = "Money: " + moneyValue;
        }

        moneyPanel.SetActive(false);
    }

    public void MinusBetMoney()
    {
        moneyText.text = "Money: " + moneyValue;
    }
}
