using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public bool isAudioOn = true;

    private void Awake()
    {

        int gameStatusCount = FindObjectsOfType<AudioHandler>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public void ToggleAudio()
    {
        if (isAudioOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
        isAudioOn = !isAudioOn;
    }
    public bool GetAudioOn()
    {
        return isAudioOn;
    }
}
