using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] int score;
    int level;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        NewGame();
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
        FindObjectOfType<Ball>().Start();
    }

}