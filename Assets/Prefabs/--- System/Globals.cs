using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] float difficulty;
#pragma warning disable 649
    //Caches
    public static Globals instance = null;
    const float BASE_DIFFICULTY = 1f;

    public float Difficulty { get => difficulty;
        set {
            difficulty = value;
            Attacker.WalkSpeedModifier = value;
        }
    }

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        Difficulty = PlayerPrefsController.GetDifficulty() == -1 
            ? BASE_DIFFICULTY 
            : PlayerPrefsController.GetDifficulty();
        Attacker.WalkSpeedModifier = Difficulty;
    }

    public float GetBaseDifficulty()
    {
        return BASE_DIFFICULTY;
    }

    private void Singleton()
    {
        if (instance != null && instance != this)
        {
            this.gameObject.SetActive(false);
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
