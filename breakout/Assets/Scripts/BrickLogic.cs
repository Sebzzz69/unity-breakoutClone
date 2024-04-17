using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    const int maxHealth = 3;
    [SerializeField] int currentHealth;

    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] state;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        switch (currentHealth)
        {
            case 1:
                spriteRenderer.sprite = state[0];
                break;

            case 2:
                spriteRenderer.sprite = state[1];
                break;

            case 3:
                spriteRenderer.sprite = state[2];
                break;

            default:
                spriteRenderer.sprite = null;
                break;

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            currentHealth--;
        }
    }
}
