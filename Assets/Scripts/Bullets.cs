using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
   public GameObject bullet;
   public Transform bulletSpawn;
   public float bulletSpeed = 20;

   Vector2 lookDirection;
   float lookAngle;

   void Update()
   {
      lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

      if (Input.GetMouseButtonDown(0))
      {
         GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);

         bulletClone.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * bulletSpeed;
      }
   }
}
