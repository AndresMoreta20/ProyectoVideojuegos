using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void FirstLevel()
    {
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
      SceneManager.LoadScene(1);
      Time.timeScale = 1;
       // SceneManager.LoadScene("Warehouse");
    }
    public void SecondLevel()
    {
    SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
