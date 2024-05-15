using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuwerUpSpawn : MonoBehaviour
{
    public GameObject powerUpPrefab; // Drag your power-up Prefab here
    public float spawnInterval = 10f; // Interval between spawns
    public BrickLogic otherScript; // Reference to your other script
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval && otherScript.currentHealth == 0)
        {
            SpawnPowerUp();
            timer = 0f;
        }
    }

    void SpawnPowerUp()
    {
        // Instantiate power-up item at random position within screen bounds
        Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 10f, 0f); // Adjust range according to your scene
        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
    }
}
