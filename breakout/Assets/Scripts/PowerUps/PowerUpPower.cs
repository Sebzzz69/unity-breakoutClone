using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpPower : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {



        Debug.Log("collided with powerUp");
        // Check if the object collided with has a specific tag
        if (collision.gameObject.CompareTag("Paddle"))
        {








            Destroy(this.gameObject);

        }
    }
}


