using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; // Upward force applied to the player

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a Rigidbody
        if (collision.rigidbody != null)
        {
            // Apply upward force instantly
            collision.rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
