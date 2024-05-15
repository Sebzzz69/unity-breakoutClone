using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] int score;
    int level;

    Text textScore;
    Text textBall;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if(textScore != null)
        {
            textScore.text = score.ToString();
        }
    }

    void NewGame()
    {
        this.score = 0;
        this.level = 3;
        this.playerHealth = 3;

        LoadLevel(1);
    }

    void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);

    }

    public void HitBrick(BrickLogic brick)
    {
        this.score += brick.GetPoints();
    }

    public void TakeDamage()
    {
        this.playerHealth--;
        textBall.text = playerHealth.ToString();
        FindObjectOfType<Ball>().Start();
    }

    public void AttachUIText()
    {
        textScore = GameObject.Find("ScoreText").GetComponent<Text>();
        textBall = GameObject.Find("BallText").GetComponent<Text>();
    }

}
