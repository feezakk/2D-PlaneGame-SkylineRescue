using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab; // Assign the bird prefab in the Inspector
    public float spawnRate = 2f;  // Time interval between spawns
    public float minY = -3.5f;    // Minimum Y position
    public float maxY = 3.5f;     // Maximum Y position
    public float spawnXPosition = 10f; // X position where the birds spawn (off-screen)

    private void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnBirds());
    }

    IEnumerator SpawnBirds()
    {
        while (true)
        {
            // Random Y position within the bounds
            float randomY = Random.Range(minY, maxY);

            // Spawn the bird at the calculated position
            Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0);
            Instantiate(birdPrefab, spawnPosition, Quaternion.identity);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
