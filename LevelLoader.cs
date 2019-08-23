using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeForLoading = 4;
    int currentSceneIndex;
    MusicPlayer musicPlayer;
    PauseButton pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        musicPlayer = FindObjectOfType<MusicPlayer>();
        pauseButton = FindObjectOfType<PauseButton>();
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoadStartScreen());
        }
        if(musicPlayer)
        {
            musicPlayer.SetVolume(PlayerPrefsController.GetMasterVolume());
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator WaitAndLoadStartScreen()
    {
        yield return new WaitForSeconds(timeForLoading);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        FindObjectOfType<OptionsController>().SaveAndExit();
        SceneManager.LoadScene("Start Screen");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void Defaults()
    {
        FindObjectOfType<OptionsController>().SetDefaults();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseButton.ChangePauseMenuStatus(false);
    }
}
