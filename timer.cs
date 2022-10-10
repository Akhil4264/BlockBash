using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text timerText;
    public Text Points;
    public Text required;
    public float startTime = 15;
    private int currentPoints = 0;
    public int pointstowin;
    
    // Update is called once per frame
    void start()
    {
        
        
    }
    void Update()
    {
        if (startTime > 0)
        {
            startTime -= Time.deltaTime;
        }
        else
        {
            startTime = 0;
        }
        DisplayTime(startTime);
        if (currentPoints == pointstowin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (startTime ==0)
        {
            SceneManager.LoadScene("lost");
        }
        
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
    public void AddPoints()
    {
        currentPoints+=1;
        Points.text =  "score : " + currentPoints;
        required.text = "/ " + pointstowin;
    }
}
