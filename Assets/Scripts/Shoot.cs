using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 5;

    public GameObject fruitCollected;
    private GameUIHandler canvas;

    private AudioSource playerAudio;

    private void Start()
    {
        fruitCollected = GameObject.FindGameObjectWithTag("Collected");
        playerAudio = GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAudio.Play();
            if (fruitCollected.activeInHierarchy)
                fruitCollected.SetActive(false);
            fruitCollected.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            fruitCollected.SetActive(true);
            canvas = GameObject.Find("Canvas").GetComponent<GameUIHandler>();
            canvas.UpdateScore(10);
        }
    }
}
