using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
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
            remainingTime = 0;
            playerScript.Dead();
        }

    }
    private void UpdateTimer()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    public void AddTime()
    {
        remainingTime += 5f;
        UpdateTimer();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
        AddTime();
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
