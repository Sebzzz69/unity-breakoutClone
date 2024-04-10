using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    const int maxHealth = 3;
    [SerializeField] int currentHealth;

    SpriteRenderer spriteRenderer;

    [SerializeField] Material[] material;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        switch (currentHealth)
        {
            case 3:
                spriteRenderer.material = material[0];
                break;

            case 2:
                spriteRenderer.material = material[1];
                break;

            case 1:
                spriteRenderer.material = material[2];
                break;

            default:
                spriteRenderer.material = null;
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
