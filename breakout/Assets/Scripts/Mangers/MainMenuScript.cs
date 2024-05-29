using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject creditPanel;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level1");
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
}
