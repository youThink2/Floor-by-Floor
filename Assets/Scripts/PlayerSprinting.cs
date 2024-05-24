using System.Collections;
using UnityEngine;

public class PlayerSprinting : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float sprintDuration = 3f; // Duration of sprint in seconds
    public float sprintRechargeDelay = 7f; // Delay before sprint starts recharging after it's fully depleted
    public float sprintRechargeRate = 1f; // Rate at which sprint recharges per second
    private float currentSprintTime; // Current remaining sprint time
    private bool isSprinting; // Flag to check if player is sprinting
    private bool isRecharging; // Flag to check if sprint is recharging

    private PlayerScript playerScript; // Reference to PlayerScript
    
    void Start()
    {
        currentSprintTime = sprintDuration;
        playerScript = GetComponent<PlayerScript>(); // Get reference to PlayerScript
    }

    void Update()
    {
        // Sprint input
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRecharging)
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || currentSprintTime <= 0)
        {
            isSprinting = false;
            if (currentSprintTime <= 0)
            {
                StartCoroutine(SprintRecharge());
            }
        }

        // Movement
        float speed = isSprinting ? sprintSpeed : moveSpeed;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Update sprint time
        if (isSprinting)
        {
            currentSprintTime -= Time.deltaTime;
        }
        else if (currentSprintTime < sprintDuration)
        {
            // Recharge sprint if not already recharging
            if (!isRecharging)
            {
                currentSprintTime += sprintRechargeRate * Time.deltaTime;
            }
        }

        currentSprintTime = Mathf.Clamp(currentSprintTime, 0f, sprintDuration);
    }

    private IEnumerator SprintRecharge()
    {
        isRecharging = true;
        yield return new WaitForSeconds(sprintRechargeDelay);
        isRecharging = false;
        currentSprintTime = sprintDuration;
    }
}
