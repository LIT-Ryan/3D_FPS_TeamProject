using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public PlayerController playerController;
    public MouseLook mouseLookScript;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (playerController.isOver == false))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

    public void Resume()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
        mouseLookScript.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }


    void Pause()

    {
        Cursor.lockState = CursorLockMode.Confined;
        mouseLookScript.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.visible = true;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlphaScene");
        Cursor.visible = false;
    }

    public void QuitGame()

    {
        Debug.Log("Quit Game");
        Application.Quit();
    }


}
