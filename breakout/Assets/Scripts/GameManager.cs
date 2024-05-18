using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] int score;

    TMP_Text textScore;
    TMP_Text textBall;

    GameObject gameOverScreen;
    GameObject pauseScreen;

    private void Awake()
    {
        AttachUIText();
        AttachUIScreens();
    }
    void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if(textScore != null)
        {
            textScore.text = "Score: " + score.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (pauseScreen.activeSelf == true)
            {
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

        pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen");
        pauseScreen.SetActive(false);
    }


}
