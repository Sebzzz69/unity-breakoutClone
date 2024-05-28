using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingScore : MonoBehaviour
{

    [SerializeField] HighscoreHandler highscoreHandler;

    public void SaveScore(string playerName, int score)
    {
        highscoreHandler.AddHighScoreIfPossible (new HighscoreElement(playerName, score));
    }
}
