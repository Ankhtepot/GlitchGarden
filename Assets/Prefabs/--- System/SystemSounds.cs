using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SystemSounds : SoundSystemImpl
{
#pragma warning disable 649
    [SerializeField] private AudioClip introSound;
    [SerializeField] private AudioClip winLevelSound;
    [SerializeField] private AudioClip loseSound;
#pragma warning restore 649

    new void Start()
    {
        base.Start();
        SetActualVolume(PlayerPrefsController.GetSoundsVolume() == -1 
            ? BaseVolume 
            : PlayerPrefsController.GetSoundsVolume());
    }

    void Update()
    {
        
    }

    public void PlayIntroSound()
    {
        PlayOnce(introSound);
    }

    public void PlayWinLevelSound()
    {
        PlayOnce(winLevelSound);
    }

    public void PlayLoseLevelSound()
    {
        PlayOnce(loseSound);
    }
}
