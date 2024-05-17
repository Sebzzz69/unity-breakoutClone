using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    [SerializeField] int maxCount = 7;

    private void Start()
    {
        LoadHighScore();
    }

    private void LoadHighScore()
    {

    }

    private void SaveHighScore()
    {

    }

    public void AddHighScoreIfPossible(HighscoreElement element)
    {

    }

}
