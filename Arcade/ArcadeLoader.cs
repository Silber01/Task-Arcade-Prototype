using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeLoader : MonoBehaviour
{
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
    public void LoadBlockBreaker()
    {
        SceneManager.LoadScene("Block Breaker");
    }
    public void LoadLaserDefense()
    {
        SceneManager.LoadScene("Laser Defense");
    }
    public void LoadCowboy()
    {
        SceneManager.LoadScene("Cowboy");
    }
}
