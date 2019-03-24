using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Fireball Games * * * PetrZavodny.com

public class OptionsBackButtonHandling : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] Slider difficulty;
    [SerializeField] Slider soundVolume;
    [SerializeField] Slider musicVolume;
#pragma warning restore 649

    public void SaveOptionsAndLoadStartScreen()
    {
        PlayerPrefsController.SetDifficulty(difficulty.value);
        PlayerPrefsController.SetSoundsVolume(soundVolume.value);
        PlayerPrefsController.SetMasterVolume(musicVolume.value);

        FindObjectOfType<SceneLoader>().LoadStartScreen();
    }
}
