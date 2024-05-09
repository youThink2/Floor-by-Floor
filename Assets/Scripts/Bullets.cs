using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
   public GameObject bullet;
   public Transform bulletSpawn;
   public Transform bulletSpawn2;
   public float bulletSpeed = 10;

   Vector2 lookDirection;
   float lookAngle;

   public AudioSource source;
   public AudioClip bulletSound;

   public float fireRate;
   float nextFire;



   void Update()
   {
      lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

      if (Input.GetMouseButtonDown(0))
      {
         if (Time.time > nextFire)
         {
            nextFire = Time.time + fireRate;
            source.clip = bulletSound;
            source.Play();
            //First bullet
            GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            bulletClone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            bulletClone.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * bulletSpeed;
            //Second bullet
            GameObject bulletClone1 = Instantiate(bullet, bulletSpawn2.position, Quaternion.identity);
            bulletClone1.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            bulletClone1.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * bulletSpeed;
         }
      }
   }

}
