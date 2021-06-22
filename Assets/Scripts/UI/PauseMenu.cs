using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private PlayerInputActions controls;

    //void Awake()
    //{
    //    //Input System
    //    controls = new PlayerInputActions();

    //    controls.GamePlay.Esc.started += ctx => Esc();
    //}

    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}

    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}

    void Start()
    {
        
    }

    void Update()
    {
        //Input Manager
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //void Esc()
    //{
    //    if (GameIsPaused)
    //    {
    //        Resume();
    //    }
    //    else
    //    {
    //        Pause();
    //    }
    //}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;

        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
