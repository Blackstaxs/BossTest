using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComands : MonoBehaviour
{
    private GameObject pauseMenu;
    private bool pauseMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        if(this.name == "PauseMenu")
        {
            pauseMenu = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                if (pauseMenuOpen)
                {
                    ClosePauseMenu();
                }
                else
                {
                    OpenPauseMenu();
                }
            }
        }
    }

    public void SetPauseMenu(GameObject menu)
    {
        pauseMenu = menu;
    }

    public void ResumeGame()
    {
        ClosePauseMenu();
        Time.timeScale = 1f;
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
