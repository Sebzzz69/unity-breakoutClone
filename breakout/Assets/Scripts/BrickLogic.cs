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
            case 1:
                points = 100;
                animator.Play("HitGreen");
                spriteRenderer.sprite = state[currentHealth - 3];
                break;

            case 2:
                points = 150;
                animator.Play("HitRed");
                spriteRenderer.sprite = state[currentHealth - 2];

                break;

            case 3:
                points = 200;
                spriteRenderer.sprite = state[currentHealth - 1];
                break;

            default:
                animator.Play("HitBlue");
                Destroy(this.gameObject);
                break;
        }
        switch (currentHealth)
        {
            //Gör om, gör rätt, din fitta
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameManager>().HitBrick(this);
            currentHealth--;
            Hit();
        }

    }

    public int GetPoints()
    {
        return this.points;
    }

}
