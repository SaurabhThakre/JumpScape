using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameUIHandler canvas;
    public GameObject grid;
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    private float posX = 950;
    private float scorePosY = 625;
    private float lifePosY = 525;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GameOver();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            canvas = GameObject.Find("Canvas").GetComponent<GameUIHandler>();
            canvas.UpdateScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit") || collision.gameObject.CompareTag("Spike"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);
        grid.gameObject.SetActive(false);
        setPosition();
    }

    public void setPosition() 
    {
        Vector3 scorePos = new Vector3(posX, scorePosY, scoreText.gameObject.transform.position.z);
        scoreText.gameObject.transform.position = scorePos;

        Vector3 lifePos = new Vector3(posX, lifePosY, lifeText.gameObject.transform.position.z);
        lifeText.gameObject.transform.position = lifePos;
    }
}
