using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    const int maxHealth = 3;
    [SerializeField] int currentHealth;
    int points;

    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] state;
    Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }



    private void Start()
    {
        currentHealth = maxHealth;
    }


    void Hit()
    {
        // Sätt sista frame i animation till 
        // respektive färg
        switch (currentHealth)
        {
            case 3:
                animator.Play("HitRed");
                points = 100;
                break;
            case 2:
                animator.Play("HitGreen");
                points = 150;
                break;
            case 1:
                animator.Play("HitBlue");
                points = 200;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameManager>().HitBrick(this);
            Hit();
            currentHealth--;
        }

    }

    public int GetPoints()
    {
        return this.points;
    }

}
