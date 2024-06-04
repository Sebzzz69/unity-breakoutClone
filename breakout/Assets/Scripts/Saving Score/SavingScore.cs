using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavingScore : MonoBehaviour
{

    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField] TMP_InputField playerID;


    private int score;


    public void SaveScore()
    {

        score = FindAnyObjectByType<GameManager>().GetScore();
        string playerName = playerID.text;
        SendScore(playerName, score);
    }

    public void SendScore(string playerName, int score)
    {
        Debug.Log("SaveScore pressed");
        highscoreHandler.AddHighScoreIfPossible (new HighscoreElement(playerName, score));
    }
}
