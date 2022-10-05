using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Singleton instance
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private Canvas gameOverCanvas;
    private Canvas scoreCanvas;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text scoreText;
    public static int currentScore;
    [SerializeField] private int largeScore;
    [SerializeField] private int mediumScore;
    [SerializeField] private int smallScore;

    //If singleton instance already exists, destroy this instance
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        GameSceneLoaded();
    }

    //Add score based on the type of asteroid destroyed
    public void AddLargeScore()
    {
        currentScore = currentScore + largeScore;
        scoreText.text = " " + currentScore;
    }
    public void AddMediumScore()
    {
        currentScore = currentScore + mediumScore;
        scoreText.text = " " + currentScore;
    }
    public void AddSmallScore()
    {
        currentScore = currentScore + smallScore;
        scoreText.text = " " + currentScore;
    }
    //When players lives are up finalise the score, send it to the game over canvas and enable it on screen
    public void FinalScore()
    {
        scoreCanvas.enabled = false;
        P_MoveForward.livesRemaining = false;
        if (gameOverScoreText == null)
        {
            gameOverScoreText = GameObject.FindWithTag("GameOverScoreText").GetComponent<TMP_Text>();
        }
        if (gameOverCanvas == null)
        {
            gameOverCanvas = GameObject.FindWithTag("GameOverCanvas").GetComponent<Canvas>();
        }
        gameOverScoreText.text = "SCORE " + currentScore;
        gameOverCanvas.enabled = true;
        StartCoroutine(ReturnToMenu());
    }
    //Waits 4 seconds before changing screens
    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Menu");
    }
    //When the game scene gets loaded reset lives and score
    public void GameSceneLoaded()
    {
        P_Lives.livesRemaining = 3;
        P_Lives.scoreClass = this;
        if (scoreCanvas == null)
        {
            scoreCanvas = GetComponent<Canvas>();
        }
        if (!scoreCanvas.enabled)
        {
            scoreCanvas.enabled = true;
        }
        currentScore = 0;
        scoreText.text = " " + currentScore;
    }
}
