using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int playerSpeed = 4;  //Players movement speed
    public int Health = 5; //Max health for player
    private int currentHealth; //Keep record of player current health

    void Start()
    {
        currentHealth = Health;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        
        transform.Translate(movementDirection * (playerSpeed * inputMagnitude * Time.deltaTime), Space.World);

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
        Debug.Log("Player Dead");
        Destroy(gameObject);
    }
}
