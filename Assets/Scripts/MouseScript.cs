using UnityEngine;

public class MouseScript : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - Camera.main.transform.position.z));

        // Calculate the direction from the player to the mouse position
        Vector3 direction = mouseWorldPosition - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float newAngle = angle - 90;
        // Rotate the player around the z-axis to face towards the mouse
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, newAngle));
    }
}