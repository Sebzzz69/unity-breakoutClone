using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject creditPanel;
    public GameObject saveScorePanel;

    public void PlayGame()
    {
        Debug.LogWarning("Level1");
        SceneManager.LoadSceneAsync("Level1");
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void QuitTheShit()
    {
        Application.Quit();
    }

    public void ShowCreditScreen()
    {
        creditPanel.SetActive(true);
    }

    public void HideCreditScreen()
    {
        creditPanel.SetActive(false);
    }

    public void ShowSaveScoreScreen()
    {
        saveScorePanel.SetActive(true);
        GameObject.FindGameObjectWithTag("GameOverScreen").SetActive(false);
    }
}
