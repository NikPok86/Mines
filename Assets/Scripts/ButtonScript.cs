using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonScript : MonoBehaviour
{
    public Sprite monkey;
    public Sprite bomb;
    public Sprite star;
    public Button button;

    public static int monkeyCount = 0;
    public bool alreadyMonkey = false;
    
    public static double multiplier = 0;
    public static double cashOutMoney;

    public GameObject betField;

    public GameObject canvas;

    public GameObject minesSet;

    public bool bombCheck = false;

    public void Start()
    {
        
    }

    public void Update()
    {        
        if (canvas.GetComponent<CanvasScript>().bombExploded)
        {
            ShowAllButtons();
        }
    }

    public void ChangeButtonImage()
    {
        if (!canvas.GetComponent<CanvasScript>().bombExploded && canvas.GetComponent<CanvasScript>().isInGame)
        {
            if (!bombCheck)
            {
                button.image.sprite = monkey;
                if (!alreadyMonkey)
                {
                    alreadyMonkey = true;
                    monkeyCount++;
                    Debug.Log(monkeyCount + " ");
                    Multiplier();

                    if (monkeyCount + minesSet.GetComponent<MinesSetScript>().numberOfMines == 25)
                    {
                        canvas.GetComponent<CanvasScript>().CashOut();
                    }
                }
                
            }

            else
            {
                cashOutMoney = 0;
                multiplier = 0;
                monkeyCount = 0;
                button.image.sprite = bomb;
                bombCheck = false;
                canvas.GetComponent<CanvasScript>().bombExploded = true;
                canvas.GetComponent<CanvasScript>().isInGame = false;
                betField.SetActive(true);
            }
        }
    }

    public void ShowAllButtons()
    {
        if (button.image.sprite == star && !bombCheck && canvas.GetComponent<CanvasScript>().bombExploded)
        {
            button.image.sprite = monkey;
        }

        else if (button.image.sprite == star && bombCheck && canvas.GetComponent<CanvasScript>().bombExploded)
        {
            button.image.sprite = bomb;
        }
    }

    public void HideAllButtons()
    {
        if (button.image.sprite != star)
        {
            button.image.sprite = star;
        }
    }

    public void Multiplier()
    {
        double a1 = 1;
        double a2 = 1;
        double p1 = 1;
        double p2 = 1;

        Debug.Log("Mines " + (25-monkeyCount));

        for (int i=1; i<=25-minesSet.GetComponent<MinesSetScript>().numberOfMines; i++)
        {
            a1 *= i;
        }

        for (int i=1; i<=25-monkeyCount; i++)
        {
            a2 *= i;
        }

        for (int i=1; i<=25; i++)
        {
            p1 *= i;
        }

        for (int i=1; i<26-monkeyCount-minesSet.GetComponent<MinesSetScript>().numberOfMines; i++)
        {
            p2 *= i;
        }

        multiplier = Math.Round(1 / ((a1 * a2) / (p1 * p2)) * 0.97, 2);
        cashOutMoney = Math.Round(multiplier * betField.GetComponent<BetScript>().betValue, 2);
        Debug.Log("Multi: " + multiplier + "CashOut: " + cashOutMoney);
    }
}
