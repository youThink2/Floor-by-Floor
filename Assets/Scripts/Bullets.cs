using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
   public GameObject bullet;
   public Transform bulletSpawn;
   public Transform bulletSpawn2;
   public Transform bulletSpawn3;
   public float bulletSpeed = 20;

   Vector2 lookDirection;
   float lookAngle;

   void Update()
   {
      lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

      if (Input.GetMouseButtonDown(0))
      {
         GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
         GameObject bulletClone1 = Instantiate(bullet, bulletSpawn2.position, Quaternion.identity);
         GameObject bulletClone2 = Instantiate(bullet, bulletSpawn3.position, Quaternion.identity);


         bulletClone.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * bulletSpeed;
         bulletClone1.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * bulletSpeed;
         bulletClone2.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * bulletSpeed;

      }
   }
}
