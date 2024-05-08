using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public int playerSpeed = 4;  //Players movement speed
    public int health = 5; //Max health for player
    private int currentHealth; //Keep record of player current health
    public Animator animator;

    private Vector2 movement;

    void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("speed", movement.sqrMagnitude);
   


        Vector2 movementDirection = new Vector2(movement.x, movement.y);
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
