using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TMP_Text clockText;
    private float seconds = 00.0f;
    private int minutes = 00;
    private int hours = 00;

    void Start(){}

    //Adds time to the timer and then updates it in the HUD
    void Update()
    {
        seconds += Time.deltaTime;
        Double secondsRounded = System.Math.Round(seconds, 2);
        if(secondsRounded >= 60.0) {
            minutes += 1;
            seconds = 0.0f;
        }
        if(minutes >= 60)
        {
            hours += 1;
            minutes = 00;
        }
        clockText.text = hours + ":" + minutes + ":" + secondsRounded;
    }
}
