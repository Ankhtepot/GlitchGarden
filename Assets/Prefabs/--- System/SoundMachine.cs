using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundMachine : MonoBehaviour
{
    [SerializeField] public SystemSounds SystemSounds;
    [SerializeField] public Music music;

    private void Start()
    {
        music.PlayMainMusic();
    }
}
