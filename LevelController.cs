using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(PlayerPrefsController.GetMasterVolume());
        }
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= Mathf.Epsilon && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        if(musicPlayer)
        {
            musicPlayer.SetVolume(0);
        }
        yield return new WaitForSeconds(waitToLoad);
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
