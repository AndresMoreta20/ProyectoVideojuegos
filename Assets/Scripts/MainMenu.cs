using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start(){
        GetComponent<AudioSource>().Play();
    }
    public void FirstLevel()
    {
        GetComponent<AudioSource>().Stop(); 
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
         SceneManager.LoadScene(1);
        Time.timeScale = 1;
       // SceneManager.LoadScene("Warehouse");
    }
    public void SecondLevel()
    {
        GetComponent<AudioSource>().Stop(); 
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        GetComponent<AudioSource>().Stop(); 
        Application.Quit();
    }
}
