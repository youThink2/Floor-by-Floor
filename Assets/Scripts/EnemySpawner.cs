using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public bool spawnImmediately = true; // Toggle to control immediate spawning
    public float spawnRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnImmediately)
        {
            SpawnGhost();
        }

        // Start the continuous spawning coroutine
        StartCoroutine(SpawnContinuously());
    }

    // Coroutine to handle continuous spawning
    private IEnumerator SpawnContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnGhost();
        }
    }

    // A simple function that spawns ghosts
    private void SpawnGhost()
    {
        Vector3 offset = new Vector3(0, 0, 0);

        // Creates a copy of the ghost on top of the spawner
        Instantiate(Enemy, transform.position + offset, Quaternion.identity);
    }
}
