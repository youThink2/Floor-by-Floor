using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealsDamage : MonoBehaviour
{
    public float push = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
         PlayerScript player = other.GetComponent<PlayerScript>();
         if (player != null)
         {
            player.TakeDamage(6); // Deals 1 damage
         }
      }
   }
}
