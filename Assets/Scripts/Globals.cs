using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    //Caches
    public static Globals instance = null;

    private void Awake()
    {
        Singleton();
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
