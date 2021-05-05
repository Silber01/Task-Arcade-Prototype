using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BBSceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadBlockBreaker()
    {
        SceneManager.LoadScene("Block Breaker");
        GameStatus resetMe = FindObjectOfType<GameStatus>();
        if (resetMe)
        {
            resetMe.ResetGame();
        }
    }

    public void LoadArcade()
    {
        SceneManager.LoadScene("Arcade");
        Destroy(FindObjectOfType<GameStatus>());
        GameStatus resetMe = FindObjectOfType<GameStatus>();
        if (resetMe)
        {
            resetMe.ResetGame();
        }
    }
}
