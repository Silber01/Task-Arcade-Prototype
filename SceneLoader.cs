using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void LoadBlockBreaker()
    {
        SceneManager.LoadScene("Block Breaker");
    }
    public void LoadArcadeDefense()
    {
        SceneManager.LoadScene("Laser Defense");
    }
    public void LoadCowboy()
    {
        SceneManager.LoadScene("Cowboy");
    }
    public void LoadArcade()
    {
        SceneManager.LoadScene("Arcade");
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
