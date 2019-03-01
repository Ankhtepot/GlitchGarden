using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    [SerializeField] private float startScreenLoadDelay = 3f;
    void Start()
    {
        FindObjectOfType<SoundMachine>().SystemSounds.PlayIntroSound();
        StartCoroutine(delayedStartScreenLoad());
    }

    IEnumerator delayedStartScreenLoad()
    {
        yield return new WaitForSecondsRealtime(startScreenLoadDelay);
        FindObjectOfType<SceneLoader>().LoadStartScreen();
    }
}
