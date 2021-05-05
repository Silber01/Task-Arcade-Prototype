using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LDLevel : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Laser Defence");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("LDGame Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToArcade()
    {
        SceneManager.LoadScene("Arcade");
        MusicPlayer destroyMe = FindObjectOfType<MusicPlayer>();
        destroyMe.DestroyMusic();
    }
}
