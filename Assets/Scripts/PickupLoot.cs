using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLoot : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Loot"))
        {
            Destroy(other.gameObject);
            Debug.Log("Item collected!");
        }
    }
}
