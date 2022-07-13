using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Paramaters
    [SerializeField] float screenWidthInUnits = 16.0f;
    [SerializeField] float maxScreenRange = 15.0f;
    [SerializeField] float minScreenRange = 1.0f;

    // Cached Reference
    GameStatus gameStatus;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getXPos(), minScreenRange, maxScreenRange);
        transform.position = paddlePos;
    }

    private float getXPos()
    {
        if (gameStatus.IsAutoPlayEnable())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            GetComponent<AudioSource>().Play();
    }
}
