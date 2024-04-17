using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    const int maxHealth = 3;
    [SerializeField] int currentHealth;
    int points;

    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] state;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    void Hit()
    {
        switch (currentHealth)
        {
            case 1:
                points = 100;
                spriteRenderer.sprite = state[0];
                break;

            case 2:
                points = 150;
                spriteRenderer.sprite = state[1];
                break;

            case 3:
                points = 200;
                spriteRenderer.sprite = state[2];
                break;

            default:
                Destroy(this.gameObject);
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            currentHealth--;
            Hit();
            FindObjectOfType<GameManager>().HitBrick(this);
        }
    }

    public int GetPoints()
    {
        return this.points;
    }

}
