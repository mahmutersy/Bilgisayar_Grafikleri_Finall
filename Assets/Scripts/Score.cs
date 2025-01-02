using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0; 
    public Text scoreText; 
    public Text highScoreText; 
    private float scoreTimer = 0f; 

    private int highScore = 0; 

    void Start()
    {
        
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
    }

    void Update()
    {
        
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= 1f)
        {
            scoreTimer = 0f;
            score += 1;
            UpdateScoreText();
        }

        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); 
            UpdateScoreText(); 
        }
    }

    
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Skor: " + score;
        }

        if (highScoreText != null)
        {
            highScoreText.text = "Yüksek Skor: " + highScore;
        }
    }

    
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    
    public int GetScore()
    {
        return score;
    }

    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
}
