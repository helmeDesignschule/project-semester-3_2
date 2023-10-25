using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private Text text;

    private int score;
    
    private void OnEnable()
    {
        instance = this;
        text.text = "0 Points";
    }

    public void IncreaseScore(int points)
    {
        if (text == null)
            return;
        
        score += points;
        text.text = score + " Points";
    }
    
}
