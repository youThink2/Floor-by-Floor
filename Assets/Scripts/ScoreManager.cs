using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public PlayerScript playerScript;
    private static ScoreManager instance;

    public TextMeshProUGUI timerText;
    private float remainingTime = 61;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        UpdateTimer();
    }

    void Update()
    {
        //Setting up a timer so when the timer is 0 player loses
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimer();
        }
        else
        {
            //Player dies if timer reaches 0
            remainingTime = 0;
            playerScript.Dead();
        }

    }
    private void UpdateTimer()
    {
        if (timerText != null)
        {
            //Making the timer format for the game
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    //Add time function
    public void AddTime()
    {
        remainingTime += 10f;
        UpdateTimer();
    }
    
    //Add score function
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    //Update the score function
    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
