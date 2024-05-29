using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public GameObject powerUpPrefab; // Reference to the power-up prefab to spawn
    public int randomInt;

    void GenerateRandomNumber()
    {
        // Generate a random number between 1 and 10 (inclusive)
        randomInt = Random.Range(1, 11);
    }


    public void SpawnPowerUp()
    {

        // Check if powerUpPrefab is assigned
        if (randomInt == 8)
        {
            // Spawn the power-up at the current position
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
    }

    public void DestroyAfterAnimation()
    {
       GenerateRandomNumber();

        //if (randomInt == 1)
            SpawnPowerUp();
        Debug.Log(randomInt);

        Destroy(gameObject);
    }

   
}
