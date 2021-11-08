using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class CanvasScript : MonoBehaviour
{
    public int[] bombPlace;
    public bool bombExploded = false;
    public int minesNumber = 1;

    public bool isGameStarted = false;
    public bool isInGame = false;

    public int bombPlaceCheck;

    public GameObject gameObject;

    public GameObject[] starButton;

    public GameObject minesSet;

    public GameObject betField;

    public Text cashOutText;

    public GameObject money;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (isGameStarted)
        {
            PlaceMines();
            isGameStarted = false;
        }

        cashOutText.text = "CASHOUT " + ButtonScript.cashOutMoney;
    }

    public void PlaceMines()
    {
        bool bombDub = false;

        for (int i=0; i<bombPlace.Length; i++)
        {
            bombDub = false;

            bombPlaceCheck = Random.Range (0,25);
            
            for (int j=0; j<bombPlace.Length; j++)
            {
                if(bombPlace[j] == bombPlaceCheck)
                {
                    bombDub = true;
                    Debug.Log("AGAIN " + bombPlaceCheck);
                }
            }

            if (!bombDub)
            {
                bombPlace[i] = bombPlaceCheck;
                gameObject = GameObject.Find("StarButton " + "(" + ("" + bombPlace[i]) + ")");
                gameObject.GetComponent<ButtonScript>().bombCheck = true;
                Debug.Log(bombPlace[i]);
            }

            else if (bombDub && i > 0)
            {
                i--;
            }
        }   
    }

    public void StartGame()
    {
        if (!isInGame)
        {
            isInGame = true;
            bombExploded = false;

            starButton = GameObject.FindGameObjectsWithTag ("StarButton");

            for (int i=0; i<starButton.Length; i++)
            {
                starButton[i].GetComponent<ButtonScript>().HideAllButtons();
                starButton[i].GetComponent<ButtonScript>().bombCheck = false;
                starButton[i].GetComponent<ButtonScript>().alreadyMonkey = false;
            }

            bombPlace = new int[minesSet.GetComponent<MinesSetScript>().numberOfMines];

            for (int i=0; i<bombPlace.Length; i++)
            {
                bombPlace[i] = 25;
            }

            isGameStarted = true;

            Debug.Log(bombPlace.Length);
        }
    }


    public void CashOut()
    {
        if (!bombExploded && isInGame)
        {
            bombExploded = true;
            isInGame = false;
            Math.Round(money.GetComponent<MoneyScript>().moneyValue +=(float) ButtonScript.cashOutMoney,2);
            ButtonScript.cashOutMoney = 0;
            ButtonScript.multiplier = 0;
            ButtonScript.monkeyCount = 0;
            betField.SetActive(true);
        }
    }
}
