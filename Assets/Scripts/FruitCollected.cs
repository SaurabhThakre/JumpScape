using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{
    public GameObject fruitCollected;
    private GameUIHandler canvas;

    private AudioSource playerAudio;
    public AudioClip collectSound;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            playerAudio.PlayOneShot(collectSound);
            if (fruitCollected.activeInHierarchy)
                fruitCollected.SetActive(false);
            fruitCollected.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            fruitCollected.SetActive(true);
            canvas = GameObject.Find("Canvas").GetComponent<GameUIHandler>();
            canvas.UpdateScore(5);
        }
    }

}
