using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Sprite monkey;
    public Sprite bomb;
    public Sprite star;
    public Button button;

    public GameObject betField;

    public GameObject canvas;

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
            }

            else
            {
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
}
