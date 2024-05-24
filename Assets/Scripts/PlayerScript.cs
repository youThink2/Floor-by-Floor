using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this namespace

public class PlayerScript : MonoBehaviour
{
    public int playerSpeed = 4;  // Base player movement speed
    public int health = 5; // Max health for player
    private int currentHealth; // Current health of the player
    public Animator animator;

    private Vector2 movement;

    public Restart restart;

    // Sprinting variables
    public float sprintSpeed = 10f;
    public float sprintDuration = 3f; // Duration of sprint in seconds
    public float sprintCooldown = 7f; // Cooldown time before sprint can be used again
    private bool isSprinting; // Flag to check if player is sprinting
    private bool canSprint = true; // Flag to check if sprint is available

    // UI element to show when sprint is available
    public GameObject sprintAvailableUI;

    void Start()
    {
        currentHealth = health;
        UpdateSprintUI();
    }

    void Update()
    {
        // Setting up movement and speed
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        animator.SetFloat("speed", movement.sqrMagnitude);

        // Check for sprint input
        if (Input.GetKeyDown(KeyCode.LeftShift) && canSprint)
        {
            StartCoroutine(Sprint());
        }

        // Calculate movement direction and magnitude
        Vector2 movementDirection = new Vector2(movement.x, movement.y);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        // Determine speed based on sprinting status
        float speed = isSprinting ? sprintSpeed : playerSpeed;

        // Apply movement
        transform.Translate(movementDirection * (speed * inputMagnitude * Time.deltaTime), Space.World);

    }

    private IEnumerator Sprint()
    {
        isSprinting = true;
        canSprint = false;
        UpdateSprintUI();
        yield return new WaitForSeconds(sprintDuration);
        isSprinting = false;
        yield return new WaitForSeconds(sprintCooldown);
        canSprint = true;
        UpdateSprintUI();
    }

    private void UpdateSprintUI()
    {
        if (sprintAvailableUI != null)
        {
            sprintAvailableUI.SetActive(canSprint);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        //Player dies and is destroyed, loading the game over screen
        Debug.Log("Player Dead");
        Destroy(gameObject);
        restart.GameOver();
    }


}
