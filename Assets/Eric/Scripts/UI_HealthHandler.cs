using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthHandler : MonoBehaviour
{
    public int Health = 6;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;

    void Start()
    {
        DisplayHealth(6);
    }


    private void DisplayHealth(int v)
    {
        Debug.Log("DisplayHealth called");
        switch (v)
        {
            case 6:
                heart1.sprite = FullHeart;
                heart2.sprite = FullHeart;
                heart3.sprite = FullHeart;
                break;
            case 5:
                heart1.sprite = FullHeart;
                heart2.sprite = FullHeart;
                heart3.sprite = HalfHeart;
                break;
            case 4:
                heart1.sprite = FullHeart;
                heart2.sprite = FullHeart;
                heart3.sprite = EmptyHeart;
                break;
            case 3:
                heart1.sprite = FullHeart;
                heart2.sprite = HalfHeart;
                heart3.sprite = EmptyHeart;
                break;
            case 2:
                heart1.sprite = FullHeart;
                heart2.sprite = EmptyHeart;
                heart3.sprite = EmptyHeart;
                break;
            case 1:
                heart1.sprite = HalfHeart;
                heart2.sprite = EmptyHeart;
                heart3.sprite = EmptyHeart;
                break;
            case 0:
                heart1.sprite = EmptyHeart;
                heart2.sprite = EmptyHeart;
                heart3.sprite = EmptyHeart;
                break;
            default:
                Debug.Log("DisplayHealth default");
                break;
        }
    }
}
