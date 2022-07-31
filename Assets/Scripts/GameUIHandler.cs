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

    private DestroyOutOfBounds gameOverObject;

    private int score = 0;
    private int life = 3;

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
