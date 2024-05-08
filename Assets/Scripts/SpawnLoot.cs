using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    public GameObject Loot;
    public Vector2 spawnMin = new Vector2(-12.83f, -10.23f);
    public Vector2 spawnMax = new Vector2(6.29f, 10.04f);

    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    public void SpawnItem()
    {
        float randomX = Random.Range(spawnMin.x, spawnMax.x);
        float randomY = Random.Range(spawnMin.y, spawnMax.y);
        Vector2 randomPos = new Vector2(randomX, randomY);

        Instantiate(Loot, randomPos, Quaternion.identity);

    } 
}
