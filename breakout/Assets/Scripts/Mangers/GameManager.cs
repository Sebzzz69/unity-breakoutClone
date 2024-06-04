using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] int score;

    [SerializeField] TMP_Text textScore;
    [SerializeField] TMP_Text textBall;

    GameObject gameOverScreen;
    GameObject pauseScreen;
    GameObject saveScoreScreen;

    private void Awake()
    {
        AttachUIText();
        AttachUIScreens();
    }
    void Start()
    {
        NewGame();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(textScore != null)
        {
            //Debug.Log("Found textscore");
            textScore.text = "Score: " + score.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (pauseScreen.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    SceneManager.LoadSceneAsync("MainMenu");
                    return;
                }


                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                return;
            }

            Time.timeScale = 0;
            pauseScreen.SetActive(true);

        }

    }

    void NewGame()
    {
        this.score = 0;
        this.playerHealth = 3;
    }

    

    public void HitBrick(BrickLogic brick)
    {
        this.score += brick.GetPoints();
    }

    public void TakeDamage()
    {

        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }

        this.playerHealth--;
        textBall.text = playerHealth.ToString();
        FindObjectOfType<Ball>().Start();
    }

    private void AttachUIText()
    {
        textScore = GameObject.Find("ScoreTxt").GetComponent<TMP_Text>();
        textBall = GameObject.Find("BallTxt").GetComponent<TMP_Text>();
    }


    // TODO::
    // Make ui handler object for this
    private void AttachUIScreens()
    {
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
        gameOverScreen.SetActive(false);

        saveScoreScreen = GameObject.FindGameObjectWithTag("SaveScoreScreen");
        saveScoreScreen.SetActive(false);

        pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen");
        pauseScreen.SetActive(false);
    }


    public int GetScore()
    {
        return score;
    }


}
