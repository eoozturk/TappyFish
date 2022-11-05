using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int gameScore;
    public static bool gameOver;
    public static bool gameStarted;

    public static Vector2 bottomLeft;

    public GameObject startPanel, gameOverPanel, scoreText; 

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        scoreText.SetActive(true);
        startPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        scoreText.SetActive(false);
        gameOverPanel.SetActive(true);
        gameScore = scoreText.GetComponent<Score>().GetScore();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
