using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 2; //Max health for enemy
    private int currentHealth; //Keep record of enemy current health

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <=0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }
}
