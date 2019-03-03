using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DefaultNamespace.enIntegers;

public class SceneLoader : MonoBehaviour
{
    //Caches
    [SerializeField] private int totalSceneCount;
    [SerializeField] private int activeSceneIndex;

    void Start()
    {
        totalSceneCount = SceneManager.sceneCountInBuildSettings;
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
    }

    public void LoadNextScene()
    {
        if (activeSceneIndex < totalSceneCount)
        {
            loadScene(++activeSceneIndex);
        }
    }

    public void LoadStartScreen()
    {
        //print("enIntegers.StartScreen is = " + (int)enIntegers.StartScreen);
        loadScene((int)StartScreen);
    }

    public void LoadGameOverScreen() {
        loadScene(totalSceneCount - 1);
    }

    private void loadScene(int sceneToBeLoaded)
    {
        SceneManager.LoadScene(sceneToBeLoaded);
    }

    public void LoadScene(int sceneToBeLoaded) {
        loadScene(sceneToBeLoaded);
    }
}