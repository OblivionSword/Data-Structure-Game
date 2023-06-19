using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject simulationSubMenu;
    [SerializeField] GameObject quizGameInstruction;

    private void Start()
    {
        titleText.SetActive(true);
        mainMenu.SetActive(true);
        simulationSubMenu.SetActive(false);
        quizGameInstruction.SetActive(false);
    }

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
