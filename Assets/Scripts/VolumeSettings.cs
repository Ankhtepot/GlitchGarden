using DefaultNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Fireball Games * * * PetrZavodny.com

[RequireComponent(typeof(Slider))]
public class VolumeSettings : MonoBehaviour
{
    public enum SoundArea
    {
        Sounds, Music
    }

#pragma warning disable 649
    [SerializeField] SoundMachine SM;
    [SerializeField] SoundArea area;
    [SerializeField] SoundSystemImpl instance;
    [SerializeField] public Slider slider;
#pragma warning restore 649

    void Start()
    {
        SM = FindObjectOfType<SoundMachine>();
        SetEffectedSoundSystem();
        SetSlider(instance.getActualVolume());
    }

    private void SetEffectedSoundSystem()
    {
        switch(area)
        {
            case SoundArea.Music : instance = FindObjectOfType<Music>() ; break;
            case SoundArea.Sounds : instance = FindObjectOfType<SystemSounds>(); break;
            default : print("No soundSystem set for VolumeSetting"); break;
        }
    }

    public void SetActualVolume()
    {
        instance.SetActualVolume(slider.value);
    }

    public void SetSlider(float value)
    {
        slider.value = value;
    }

    public void SetDefaultVolume()
    {
        SetSlider(instance.BaseVolume);
    }
}
