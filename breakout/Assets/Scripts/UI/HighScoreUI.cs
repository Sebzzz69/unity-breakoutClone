using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }


}
