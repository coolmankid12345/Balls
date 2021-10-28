using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    float startingTime = 120f; // * Time.timeScale adjusted to current timeScale
    bool touched = false;
    public Text timerText;
    public AudioSource BGM;
    //public AudioClip clip;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if(touched && currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime / Time.timeScale;//adjusted to current timeScale
        }

        if(currentTime > 0 && currentTime < startingTime)
        {
            if (BGM.clip.name == "Full_Send (1)")//Tests to make sure still on roof essentially
            {
                if (currentTime >= 70)
                {
                    timerText.text = "1:" + ((int)currentTime - 60); //Int cast truncates and "calculates" the minute dif
                }
                else if (currentTime >= 60)
                {
                    timerText.text = "1:0" + ((int)currentTime - 60);
                }
                else if (currentTime > 14) //Display as whole numbers until 30 seconds left
                {
                    timerText.text = "" + (int)currentTime; //Int cast truncates
                }
                else//For some reason does not display as a float
                {
                    timerText.text = "" + (float)currentTime;
                }
            }
            else
            {
                timerText.text = "";
                currentTime = 0;
            }
        }
        else
        {
            timerText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touched = true;
        }
    }
}
