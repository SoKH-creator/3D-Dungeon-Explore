using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemPickup : MonoBehaviour
{
    public ItemData item;    // Assign in Inspector
    public int amount = 1;   // How many items to give

    private void Reset()
    {
        // Ensure trigger collider for simple pickups
        var col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Expect the player root to have Inventory
        var inv = other.GetComponentInParent<Inventory>();
        if (inv == null) return;

        inv.AddItem(item, amount);
        // Optionally play VFX/SFX here

        Destroy(gameObject); // Remove pickup after collecting
    }
}
