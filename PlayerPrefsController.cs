using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string MASTER_DIFFICULTY_KEY = "master difficulty";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master Volume is out of RANGE!!!");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetMasterDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(MASTER_DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Master Difficulty is out of RANGE!!!");
        }
    }

    public static float GetMasterDifficulty()
    {
        return PlayerPrefs.GetFloat(MASTER_DIFFICULTY_KEY);
    }
}
