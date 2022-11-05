using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    Text scoreText;

    public GameObject newBest;
    public Text panelScore, panelHighScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
    }

    public void updateScore()
    {
        if(GameManager.gameStarted == true)
        {
            score++;
            scoreText.text = score.ToString();
            panelScore.text = score.ToString();
        }
     
        if(score > highScore)
        {
            highScore = score;
            newBest.SetActive(true);
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
