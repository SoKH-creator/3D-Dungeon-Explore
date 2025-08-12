using UnityEngine;
using UnityEngine.UI;

public class RayInspectUI : MonoBehaviour
{
    public Camera cam;                     // Camera used to raycast (usually main)
    public LayerMask inspectMask;          // Layers to be inspected (e.g., Interactable, Default, Rock)
    public float maxDistance = 10f;        // Max ray distance

    public Text nameText;                  // UI Text for name (or TMP_Text)
    public Text descText;                  // UI Text for description

    void Reset()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Build a ray from the center of the screen (crosshair position)
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (CheckInspectable(ray))
            return;
        
        // Clear UI if nothing valid is hit
        if (nameText) nameText.text = "";
        if (descText) descText.text = "";
    }

    private bool CheckInspectable(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, inspectMask, QueryTriggerInteraction.Ignore))
        {
            // Try to get an Inspectable component from the hit object or its parents
            if (hit.collider.TryGetComponent<Inspectable>(out var info) ||
                hit.collider.GetComponentInParent<Inspectable>() != null && (info = hit.collider.GetComponentInParent<Inspectable>()) != null)
            {
                // Update UI with object info
                if (nameText) nameText.text = info.displayName;
                if (descText) descText.text = info.description;
                return true;
            }
        }

        return false;
    }
}
