using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        //If the singleton instance of scoreManager exists then this must be a 2nd+ playthrough, call method
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.GameSceneLoaded();
        }
        //Load the game scene
        SceneManager.LoadScene("SampleScene");
    }
}
