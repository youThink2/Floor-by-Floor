using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    public GameObject Loot;
    public Vector2 spawnMin = new Vector2(-17.83f, -14.36f);
    public Vector2 spawnMax = new Vector2(11.49f, 15.79f);
    public float minDistance = 5.0f; // Minimum distance between consecutive spawns

    private Vector2 lastSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    // Function to spawn a loot item
    public void SpawnItem()
    {
        Vector2 randomPos;

        do
        {
            float randomX = Random.Range(spawnMin.x, spawnMax.x);
            float randomY = Random.Range(spawnMin.y, spawnMax.y);
            randomPos = new Vector2(randomX, randomY);
        } while (Vector2.Distance(randomPos, lastSpawnPosition) < minDistance);

        Instantiate(Loot, randomPos, Quaternion.identity);
        // Update the last spawn position
        lastSpawnPosition = randomPos; 
    }
}