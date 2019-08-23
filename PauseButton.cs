using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject pauseLabel;

    // Start is called before the first frame update
    void Start()
    {
        ChangePauseMenuStatus(false);
    }

    private void OnMouseDown()
    {
        Time.timeScale = 0;
        ChangePauseMenuStatus(true);
    }

    public void ChangePauseMenuStatus(bool status)
    {
        pauseLabel.SetActive(status);
    }
}
