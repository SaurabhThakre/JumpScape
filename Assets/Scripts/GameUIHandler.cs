using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    public TextMeshProUGUI BestScoreText;

    private DestroyOutOfBounds gameOverObject;

    private int score = 0;
    private int life = 3;

    private void Start()
    {
        if (MainManager.Instance.loadScore != 0)
        {
            BestScoreText.text = "Best Score : " + MainManager.Instance.loadName + " : " + MainManager.Instance.loadScore;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
        updateBestScore();
    }

    public void UpdateLife(int lifeToRemove)
    {
        life -= lifeToRemove;
        lifeText.text = "Life : " + life;
        if (life == 0)
        {
            gameOverObject = GameObject.Find("CollisonBoundBottom").GetComponent<DestroyOutOfBounds>();
            gameOverObject.GameOver();
        }
    }

    public void updateBestScore()
    {
        if (MainManager.Instance.loadScore < score)
        {
            MainManager.Instance.Score = score;
            MainManager.Instance.SaveBestScore();
            BestScoreText.text = "Best Score : " + MainManager.Instance.Name + " : " + MainManager.Instance.Score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        updateBestScore();
        MainManager.Instance.LoadBestScore();
    }

}
