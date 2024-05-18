using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPower : MonoBehaviour
{
    // This method is called when the object collides with another object with a collider
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        // Check if the object collided with has a specific tag
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("Collided with object with tag 'YourTag'");
            // Do something when collision occurs with an object with the specified tag
        }
    }
}
