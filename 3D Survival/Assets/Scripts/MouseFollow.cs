using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    public Camera cam;                 // Reference to the main camera
    public LayerMask groundMask;       // Layers that can be targeted by the mouse
    public float followSpeed = 15f;    // Smooth follow speed
    public float yOffset = 0.0f;       // Vertical offset from hit point

    void Reset()
    {
        // Automatically set the main camera if not assigned
        cam = Camera.main;
    }

    void Update()
    {
        // Get the current mouse position on screen
        Vector2 mousePos = Mouse.current != null
            ? Mouse.current.position.ReadValue()
            : (Vector2)Input.mousePosition; // Fallback to old Input if needed

        // Create a ray from the camera through the mouse position
        Ray ray = cam.ScreenPointToRay(mousePos);

        // Perform a raycast to detect objects on the specified layer
        if (Physics.Raycast(ray, out RaycastHit hit, 2000f, groundMask, QueryTriggerInteraction.Ignore))
        {
            // Target position is the point where the ray hit the object
            Vector3 target = hit.point;
            target.y += yOffset; // Add vertical offset if necessary

            // Smoothly move this object towards the target point
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * followSpeed);
        }
    }
}
