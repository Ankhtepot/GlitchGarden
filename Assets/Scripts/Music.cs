using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Music : SoundSystemImpl
{
#pragma warning disable 649
    [SerializeField] private AudioClip mainMusic;
#pragma warning restore 649

    new void Start()
    {
        base.Start();
        SetActualVolume(PlayerPrefsController.GetMasterVolume() == -1
            ? BaseVolume
            : PlayerPrefsController.GetMasterVolume());
    }

    void Update()
    {

    }

    public void PlayMainMusic()
    {
        PlayOnce(mainMusic);
    }

    
}
