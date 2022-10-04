using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class P_Lives
{
    public static int livesRemaining;
    public static ScoreManager scoreClass;

    public static void MinusLife()
    {
        if (livesRemaining >= 2)
        {
            livesRemaining--;
        }
        else
        {
            livesRemaining = 0;
            scoreClass.FinalScore();
        }
    }
}
