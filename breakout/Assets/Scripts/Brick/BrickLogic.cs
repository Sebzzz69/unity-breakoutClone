using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    const int maxHealth = 3;
    public int currentHealth;
    int points = 100;

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
                // REd dont give pints

                points = 100;
                animator.Play("HitRed");
                break;
            case 2:
                points = 150;
                animator.Play("HitGreen");
                break;
            case 1:
                points = 200;
                animator.Play("HitBlue");
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
