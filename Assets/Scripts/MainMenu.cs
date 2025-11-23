using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        //RestartingGame();
    }

    //public void Credits()
    //{
    //    SceneManager.LoadScene("Credits");
    //}

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    //public void RestartingGame()
    //{
    //    Time.timeScale = 1f;
    //    PauseController.SetPause(false);
    //}
}