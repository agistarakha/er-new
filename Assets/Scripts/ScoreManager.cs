using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [Header("Text UI")]
    public Text scoreText;
    public Text highScoreText;

    private int score;
    private float timer;
    private int highScore;

    public static ScoreManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        timer = 2f;
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + highScore;
        //Debug.Log(highScore);
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            score++;
            scoreText.text = "Score: " + score;
            timer = 2f;
        }
    }

    public void SetHighScore()
    {
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
