using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;   // The player object that moves (yaw rotation)
    public Transform cam;           // Camera transform (pitch rotation)
    public float mouseSensitivity = 100f; // Mouse sensitivity

    private float xRotation = 0f;   // Current camera pitch

    private void Start()
    {
        // Lock the cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get mouse delta from new Input System (fallback to old Input if needed)
        Vector2 mouseDelta = Mouse.current != null
            ? Mouse.current.delta.ReadValue()
            : new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        // Rotate camera pitch (invert Y if needed)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Limit vertical look

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player yaw
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
