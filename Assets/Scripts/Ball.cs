
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuaration Paramaters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2.0f, yPush = 15.0f, randomFactor = 0.5f;


    // State Variables
    Vector2 paddleToBallGap;
    bool hasStarted = false;

    // Chached Reference
    Rigidbody2D myRigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallGap = transform.position - paddle1.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallGap;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0.1f, randomFactor), Random.Range(0.1f, randomFactor));
        if (hasStarted)
        {
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
