using Assets.Scripts.constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fireball Games * * * PetrZavodny.com

public class PlayerPrefsController : MonoBehaviour
{
#pragma warning disable 649
    
#pragma warning restore 649

    public static void SetMasterVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        PlayerPrefs.SetFloat(system.MASTER_VOLUME, volume);
    }

    public static void SetSoundsVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        PlayerPrefs.SetFloat(system.SOUND_VOLUME, volume);
    }

    public static void SetDifficulty(float difficulty)
    {
        difficulty = Mathf.Clamp(difficulty, 0, 3);
        PlayerPrefs.SetFloat(system.DIFFICULTY, difficulty);
    }

    public static float GetMasterVolume()
    {
        print("Loading masterVolume: " + (PlayerPrefs.HasKey(system.MASTER_VOLUME) ? PlayerPrefs.GetFloat(system.MASTER_VOLUME) : -1));
        return PlayerPrefs.HasKey(system.MASTER_VOLUME) ? PlayerPrefs.GetFloat(system.MASTER_VOLUME) : -1;
    }

    public static float GetSoundsVolume()
    {
        return PlayerPrefs.HasKey(system.SOUND_VOLUME) ? PlayerPrefs.GetFloat(system.SOUND_VOLUME) : -1;
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.HasKey(system.DIFFICULTY) ? PlayerPrefs.GetFloat(system.DIFFICULTY) : -1;
    }
}
