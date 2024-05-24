using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   //Bulet life seconds
   public float life = 1;

    void Awake()
   {
        Destroy(gameObject, life);
   }

   void OnTriggerEnter2D(Collider2D other)
   {
      //When bullet comes in contact with enemy tag
      if (other.CompareTag("Enemy"))
      {
         EnemyHealth enemy = other.GetComponent<EnemyHealth>();
         if (enemy != null)
         {
            // Deals 1 damage
            enemy.TakeDamage(1); 
            Destroy(gameObject);
         }
      }
      //When bullet comes in conact with Collider tag
      else if (other.CompareTag("Collider"))
      {
         Destroy(gameObject);
      }
   }
}

