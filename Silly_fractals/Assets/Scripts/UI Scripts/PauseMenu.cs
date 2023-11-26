using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject traderUI;

    
    void Update()
    {
        if (!settingsMenuUI.activeSelf)
        {
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
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PlayerManager.instance.player.GetComponent<PlayerRotation>().enabled = true;
        GameIsPaused = false;
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PlayerManager.instance.player.GetComponent<PlayerRotation>().enabled = false;
        EnemiesManager.instance.HatchesTextOff();
        GameIsPaused = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(1);
    }

    public void CloseTraderUI()
    {
        traderUI.SetActive(false);
        PlayerManager.instance.player.GetComponent<Shooting>().enabled = true;
    }
}
