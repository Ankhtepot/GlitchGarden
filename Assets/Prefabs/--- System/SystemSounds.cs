using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SystemSounds : SoundSystemImpl
{
#pragma warning disable 649
    [SerializeField] private AudioClip introSound;
#pragma warning restore 649

    new void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }

    public void PlayIntroSound()
    {
        PlayOnce(introSound);
    }
}
