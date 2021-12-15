using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
                Resume();
            else
                Pause();
        }
    }


    void Resume()
    {
        pauseMenuUI.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        IsGamePaused = true;
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
