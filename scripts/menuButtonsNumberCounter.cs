using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuButtonsNumberCounter : MonoBehaviour
{
    public Sprite[] menuNumbers;
    public int currentButton;
    public Image myImg;

    private void Start()
    {
        myImg.sprite = menuNumbers[currentButton];
    }


    public void changeButton()
    {
        myImg.sprite = menuNumbers[currentButton];
    }
}
