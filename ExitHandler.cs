using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHandler : MonoBehaviour
{
    
    public void destroyMusic()
    {
        MusicPlayer destroyMe = FindObjectOfType<MusicPlayer>();
        destroyMe.DestroyMusic();
    }

}

