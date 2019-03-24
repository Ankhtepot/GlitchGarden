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
    [SerializeField] private int optionsSceneIndex = 4;
    [SerializeField] private int firstLevelSceneIndex = 2;

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
        print("In LoadNextScene");
        if (activeSceneIndex < totalSceneCount)
        {
            print("New level shuld be loaded");
            loadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void ReloadScene()
    {
        loadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void loadOptionsScreen()
    {
        loadScene(optionsSceneIndex);
    }

    public void LoadFirstLevel()
    {
        loadScene(firstLevelSceneIndex);
    }
}