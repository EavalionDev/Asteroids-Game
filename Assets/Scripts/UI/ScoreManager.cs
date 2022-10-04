using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static bool sceneChange;
    [SerializeField] private Canvas gameOverCanvas;
    private Canvas scoreCanvas;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text scoreText;
    private int currentScore;
    [SerializeField] private int largeScore;
    [SerializeField] private int mediumScore;
    [SerializeField] private int smallScore;

    void Start()
    {
        P_Lives.livesRemaining = 3;
        sceneChange = false;
        P_Lives.scoreClass = this;
        scoreCanvas = GetComponent<Canvas>();
        if (!scoreCanvas.enabled)
        {
            scoreCanvas.enabled = true;
        }
        currentScore = 0;
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
        GameOverManager.scoreText = gameOverScoreText;
        GameOverManager.ShowScore(currentScore);
        gameOverCanvas.enabled = true;
        StartCoroutine(ReturnToMenu());
        sceneChange = true;
    }
    //Waits 4 seconds before changing screens
    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Menu");
    }
}
