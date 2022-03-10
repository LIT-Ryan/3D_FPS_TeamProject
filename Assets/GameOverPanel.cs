using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverPanel : MonoBehaviour
{
 
    


    void Update()
    {
 

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = false;
    }


    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("AlphaScene");
    }

    public void QuitGame()

    {
        Debug.Log("Quit Game");
        Application.Quit();
    }


}
