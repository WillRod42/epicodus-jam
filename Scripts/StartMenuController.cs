using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public string mainSceneName;
    public GameObject startMenu;
    public GameObject settingsMenu;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }

    public void SettingsMenu()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void StartMenu()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
