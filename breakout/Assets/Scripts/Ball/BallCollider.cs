using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    public float velocityMagnitude; // Magnitude of the velocity to be applied
    private Rigidbody2D rb; // Rigidbody component of the object

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(rb.velocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("penis2");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggerd");
            // Get the current velocity of the ball
            Vector2 currentVelocity = rb.velocity;

            // Calculate the direction towards the trigger collider
            Vector2 directionToCollider = (other.transform.position - transform.position).normalized;

            // Reverse the direction to bounce back
            Vector2 bounceDirection = -directionToCollider;

            // Apply the bounce direction while maintaining the same speed
            rb.velocity = bounceDirection * currentVelocity.magnitude;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("unntriggerd");

            // Reset velocity when exiting the trigger collider
            //rb.velocity = Vector2.zero;
        }
    }
}
