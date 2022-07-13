using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    // Serialized Fields
    [Range(0.1f, 5.5f)][SerializeField] float gameSpeed = 1.0f;
    [SerializeField] int pointsPerBlock = 77;
    [SerializeField] Text textScore;
    [SerializeField] bool autoPlay;

    // State Variable
    [SerializeField] int score = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        textScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddPlayerScore()
    {
        score += pointsPerBlock;
        textScore.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnable()
    {
        return autoPlay;
    }
}
