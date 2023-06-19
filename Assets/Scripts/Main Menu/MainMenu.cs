using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void LoadScene(string sceneName)
    {
        //string sceneName = scene.name;
        SceneManager.LoadScene(sceneName);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
