using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    [SerializeField] int maxCount = 7;
    [SerializeField] string filename;


    private void Start()
    {
        LoadHighScore();
    }

    private void LoadHighScore()
    {
        highscoreList = FileHandler.ReadFromJSON<HighscoreElement>(filename);

        while (highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }
    }

    private void SaveHighScore()
    {
        FileHandler.SaveToJSON<HighscoreElement>(highscoreList, filename);
    }

    public void AddHighScoreIfPossible(HighscoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highscoreList.Count || element.points > highscoreList[i].points)
            {
                // Add new high score
                highscoreList.Insert(i, element);

                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                SaveHighScore();
                break;
            }
        }
    }

}
