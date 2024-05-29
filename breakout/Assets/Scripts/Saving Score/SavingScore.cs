using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingScore : MonoBehaviour
{

    [SerializeField] HighscoreHandler highscoreHandler;


    private int score;
    public string playerName;


    public void SaveScore()
    {

        score = FindAnyObjectByType<GameManager>().GetScore();

        SendScore(playerName, score);
    }

    public void SendScore(string playerName, int score)
    {
        Debug.Log("SaveScore pressed");
        highscoreHandler.AddHighScoreIfPossible (new HighscoreElement(playerName, score));
    }
}
