using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = 1f;
        moveSpeed = 1f;
    }

    private void Update()
    {

        float playerPos = (float)System.Math.Round(transform.position.x, 1);
        float leftEnd = (float)System.Math.Round((transform.parent.position.x - 1.2f), 1);
        float rightEnd = (float)System.Math.Round((transform.parent.position.x + 1f), 1);

        if (playerPos < leftEnd)
        {
            dirX = 1;
        }
        else if(playerPos > rightEnd)
        {
            dirX = -1;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = false;
        else if (dirX < 0)
            facingRight = true;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

}
