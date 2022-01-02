using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject pauseMenuUI;
    public Text MenuText;

    private bool MenuBlocked = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuBlocked)
        {
            if (IsGamePaused)
                Resume();
            else
                Pause("PAUSED");
        }
    }


    void Resume()
    {
        pauseMenuUI.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1;
    }

    void Pause(string text)
    {
        MenuText.text = text;
        pauseMenuUI.SetActive(true);

        IsGamePaused = true;
        Time.timeScale = 0;
    }

    public void PlayerDied()
    {
        MenuBlocked = true;
        Pause("YOU DIED");
    }

    public void PlayerWon()
    {
        MenuBlocked = true;
        Pause("YOU WON");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
