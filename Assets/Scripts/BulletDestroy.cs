using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float life = 1;

    void Awake()
   {
        Destroy(gameObject, life);
   }

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Enemy"))
      {
         EnemyHealth enemy = other.GetComponent<EnemyHealth>();
         if (enemy != null)
         {
            enemy.TakeDamage(1); // Deals 1 damage
            Destroy(gameObject);
         }
      }
   }
}
