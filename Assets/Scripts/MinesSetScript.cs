using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesSetScript  : MonoBehaviour
{
    public Text minesText;
    public Button plusButton;
    public Button minusButton;

    public GameObject canvas;

    public int numberOfMines = 1;

    void Start()
    {
        minesText.text = "Mines: " + numberOfMines;
    }

    void Update()
    {
        
    }

    public void PlusMinesSet()
    {
        if (numberOfMines < 24 && !canvas.GetComponent<CanvasScript>().isInGame)
        {
            numberOfMines++;
            minesText.text = "Mines: " + numberOfMines;
        }
        
    }

    public void MinusMinesSet()
    {
        if (numberOfMines > 1 && !canvas.GetComponent<CanvasScript>().isInGame)
        {
            numberOfMines--;
            minesText.text = "Mines: " + numberOfMines;
        }

    }
}
