using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOverManager
{
    public static TMP_Text scoreText;

    public static void ShowScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }
}
