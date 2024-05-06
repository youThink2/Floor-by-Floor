using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public float spawnRate = 1;
    private float timer = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        SpawnGhost();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnGhost();
            timer = 5;
        }
    }

    // A simple function that spawns logs
    private void SpawnGhost()
    {
        // Find a position to offset
        //float lowestPoint = -heightOffset;
       // float highestPoint = heightOffset;

        Vector3 offset = new Vector3(0, 0, 0);
        
        // Creates a copy of the logs on top of the spawner
        Instantiate(Enemy, transform.position + offset, Quaternion.identity);
    }
}
