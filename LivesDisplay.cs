using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetMasterDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
        //Debug.Log("difficulty setting currently is " + PlayerPrefsController.GetMasterDifficulty());
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives = lives - damage;
        UpdateDisplay();
        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
