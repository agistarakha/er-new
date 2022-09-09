using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public bool isGameOver;
    public Image gameOverPanel;

    public static GameManager Instance { get; private set; }
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
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameOver)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        isGameOver = true;
        ScoreManager.Instance.SetHighScore();

    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
