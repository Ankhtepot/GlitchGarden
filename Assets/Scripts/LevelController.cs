using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//Fireball Games * * * PetrZavodny.com

public class LevelController : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;
    [SerializeField] ParticleSystem loseEffect;
    [SerializeField] int attackersCount = 0;
    [SerializeField] public bool levelTimerFinished = false;
    [SerializeField] SoundMachine SM;
    [SerializeField] SceneLoader SL;
    [SerializeField] float loadNextLevelDelay = 2f;
    [SerializeField] GameObject loseEffectParent;
#pragma warning restore 649

    private void Start()
    {
        SM = FindObjectOfType<SoundMachine>();
        SL = FindObjectOfType<SceneLoader>();
        OnLevelLoadActions();
    }

    private void OnLevelLoadActions()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void substractAttacker()
    {
        //print("GC subAtt called, attackersCOunt is: " + attackersCount--);
        attackersCount--;
        if (levelTimerFinished && attackersCount <= 0 && FindObjectOfType<BaseCollider>()?.getBaseColliderHealth() > 0)
        {

            StartCoroutine(HandleNewLevelLoad());
        }
    }

    private IEnumerator HandleNewLevelLoad()
    {
        winText.gameObject.SetActive(true);
        SM.SystemSounds.PlayWinLevelSound();
        yield return new WaitForSecondsRealtime(loadNextLevelDelay);
        print("next level should load now");
        SL.LoadNextScene();
    }

    public void HandleLosingLevel()
    {
        loseText.gameObject.SetActive(true);
        if (loseEffect)
        {
            Instantiate(loseEffect, transform.position, transform.rotation);
        }
        SM.SystemSounds.PlayLoseLevelSound();
        //Time.timeScale = 0;
    }

    public void addAttacker()
    {
        ++attackersCount;
    }

    public void setLevelTimerFinished(bool state)
    {
        levelTimerFinished = state;
        if (levelTimerFinished)
        {
            foreach(AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
                spawner.StopSpawning();
        }
    }
}
