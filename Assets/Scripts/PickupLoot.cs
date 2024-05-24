using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupLoot : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Loot"))
        {
            Destroy(other.gameObject);
            Debug.Log("Item collected!");
            //Adds score
            //ScoreManager score = FindObjectOfType<ScoreManager>();
            //score.AddScore(1);
            SpawnLoot spawn = FindObjectOfType<SpawnLoot>();
            spawn.SpawnItem();
            ScoreManager score = FindObjectOfType<ScoreManager>();
            score.AddTime();
        }
    }
}
