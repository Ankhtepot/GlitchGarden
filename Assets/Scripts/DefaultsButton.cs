using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Fireball Games * * * PetrZavodny.com

public class DefaultsButton : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private float difficulty;
    [SerializeField] VolumeSettings soundSetting;
    [SerializeField] DifficultySetting difficultySetting;
#pragma warning restore 649

    private void Start()
    {
        difficulty = FindObjectOfType<Globals>().GetBaseDifficulty();
    }

    public void SetDefaults()
    {
        soundSetting.SetDefaultVolume();
        difficultySetting.SetDefaultValue();
    }
}
