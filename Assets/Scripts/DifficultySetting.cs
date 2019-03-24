using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Fireball Games * * * PetrZavodny.com
[RequireComponent(typeof(Slider))]
public class DifficultySetting : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] Globals globals;
    [SerializeField] public Slider slider;
#pragma warning restore 649

    void Start()
    {
        globals = FindObjectOfType<Globals>();
        SetSlider(globals.Difficulty);
    }

    public void SetDifficulty()
    {
        globals.Difficulty = slider.value;
    }

    public void SetSlider(float value)
    {
        slider.value = value;
    }

    public void SetDefaultValue()
    {
        SetSlider(globals.GetBaseDifficulty());
    }
}
