using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
#pragma warning disable 649
#pragma warning restore 649
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 10;

    bool timerExpired = false;

    void Update()
    {
        if (timerExpired) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        if(Time.timeSinceLevelLoad >= levelTime)
        {
            print("Level timer expired");
            timerExpired = true;
            FindObjectOfType<LevelController>().setLevelTimerFinished(true);
        }
    }

    
}
