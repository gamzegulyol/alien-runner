using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void returnMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
        Score.score = 0;

    }
    public void returnGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        Score.score = 0;
    }

  



}
