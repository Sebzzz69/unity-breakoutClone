using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpItem : MonoBehaviour
{
    public float speed = 2f; // Speed of the falling item
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the item downwards
        rb.velocity = new Vector2(0, -speed);
    }

    // You can add collision logic here if you want the item to do something when the player picks it up
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Example: Increase player's health
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                
                Debug.Log("logik power up"); //LOGIK!!
            }

            // Destroy the power-up item
            Destroy(gameObject);
        }
    }
}
