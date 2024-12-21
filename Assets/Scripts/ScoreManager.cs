using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int playerScore = 0;

    private void Start()
    {  
        playerScore = 0;
        UpdateScoreText();
    }
    public void IncrementScoreBy1()
    {
        playerScore++;
        UpdateScoreText();
    }

    public void IncrementScoreBy3()
    {
        playerScore += 3;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
}
