using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    public Transform target;    // The object that follows the mouse (MouseFollow)

    public float turnSpeed = 10f; // How fast the player rotates towards the target

    void Update()
    {
        // Calculate the direction from player to target on the XZ plane
        Vector3 direction = (new Vector3(target.position.x, transform.position.y, target.position.z)) - transform.position;

        // Skip if direction is almost zero
        if (direction.sqrMagnitude < 0.0001f) return;

        // Calculate the desired rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
    }
}
