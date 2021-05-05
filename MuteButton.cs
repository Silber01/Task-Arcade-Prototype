using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] Sprite unmuted;
    [SerializeField] Sprite muted;
    [SerializeField] AudioHandler audioHandler;
    bool isAudioOn;

    private void Start()
    {
        audioHandler = FindObjectOfType<AudioHandler>();
        isAudioOn = audioHandler.GetAudioOn();
        SetSprites();
        
    }

    public void ToggleMute()
    {
        isAudioOn = !isAudioOn;
        SetSprites();
        audioHandler.ToggleAudio();
    }
    public void SetSprites()
    {
        if (isAudioOn)
        {
            this.GetComponent<Image>().sprite = unmuted;
        }
        else
        {
            this.GetComponent<Image>().sprite = muted;
        }
    }
}
