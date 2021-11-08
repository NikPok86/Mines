using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BetScript : MonoBehaviour
{
    public Text betText;
    public Text realBetText;
    public GameObject money;
    public GameObject canvas;
    public GameObject errorbet;
    public GameObject betField;

    public double betValue;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        if (!canvas.GetComponent<CanvasScript>().isInGame)
        {
            betValue = Convert.ToDouble(betText.text);
            errorbet.SetActive(false);

            if (money.GetComponent<MoneyScript>().moneyValue < betValue || betValue < 0)
            {
                errorbet.SetActive(true);
            }

            else
            {
                canvas.GetComponent<CanvasScript>().StartGame();
                money.GetComponent<MoneyScript>().moneyValue -=(float) betValue;
                money.GetComponent<MoneyScript>().MinusBetMoney();
                realBetText.text = "BET: " + betText.text;
                betField.SetActive(false);
            }
        }
    }
}
