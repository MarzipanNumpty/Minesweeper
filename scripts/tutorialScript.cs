using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public GameObject[] tutorialSlides;
    public int currentSlide = 0;
    public Text pageNumber;

    public void increaseSlide()
    {
        if(currentSlide != tutorialSlides.Length - 1)
        {
            tutorialSlides[currentSlide].SetActive(false);
            currentSlide++;
            int num1 = currentSlide + 1;
            int num2 = tutorialSlides.Length;
            pageNumber.text = num1.ToString() + " / " + num2.ToString();
            tutorialSlides[currentSlide].SetActive(true);
        }
    }

    public void decreaseSlide()
    {
        if(currentSlide != 0)
        {
            tutorialSlides[currentSlide].SetActive(false);
            currentSlide--;
            int num1 = currentSlide + 1;
            int num2 = tutorialSlides.Length;
            pageNumber.text = num1.ToString() + " / " + num2.ToString();
            tutorialSlides[currentSlide].SetActive(true);
        }
    }
}
