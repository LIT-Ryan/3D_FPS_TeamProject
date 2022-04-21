using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCompletedPanel : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
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
