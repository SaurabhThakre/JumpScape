using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObstacleCollison : MonoBehaviour
{
    public GameObject fruitCollected;
    private GameUIHandler canvas;

    private IEnumerator coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coroutine = PlayerInactiveWait(1f);

        if (collision.gameObject.CompareTag("Spike"))
        {
            if (fruitCollected.activeInHierarchy)
                fruitCollected.SetActive(false);
            fruitCollected.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            fruitCollected.SetActive(true);
            StartCoroutine(coroutine);
            canvas = GameObject.Find("Canvas").GetComponent<GameUIHandler>();
            canvas.UpdateLife(1);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        coroutine = PlayerInactiveWait(1f);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (fruitCollected.activeInHierarchy)
                fruitCollected.SetActive(false);
            fruitCollected.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            fruitCollected.SetActive(true);
            StartCoroutine(coroutine);
            canvas = GameObject.Find("Canvas").GetComponent<GameUIHandler>();
            canvas.UpdateLife(1);
        }
    }

    private IEnumerator PlayerInactiveWait(float waitTime)
    {
        float posZ = transform.position.z;
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, 100);
        transform.position = playerPos;
        yield return new WaitForSeconds(waitTime);
        playerPos = new Vector3(transform.position.x, transform.position.y, posZ);
        transform.position = playerPos;
    }

}
