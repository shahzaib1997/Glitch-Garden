using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our Level Timer in Seconds")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;
    [SerializeField] bool timerFinished;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished == false)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
            timerFinished = (Time.timeSinceLevelLoad >= levelTime);
            if (timerFinished)
            {
                FindObjectOfType<LevelController>().LevelTimerFinished();
                triggeredLevelFinished = true;
            }
        }
    }
}
