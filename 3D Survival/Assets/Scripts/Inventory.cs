using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class ItemStack
    {
        public ItemData data;
        public int count;

        public ItemStack(ItemData d, int c) { data = d; count = c; }
    }

    public List<ItemStack> items = new List<ItemStack>();

    // Adds an item; merges stack if possible
    public void AddItem(ItemData item, int amount = 1)
    {
        if (item == null || amount <= 0) return;

        if (item.stackable)
        {
            var existing = items.Find(s => s.data == item);
            if (existing != null)
            {
                existing.count = Mathf.Min(existing.count + amount, item.maxStack);
                Debug.Log($"[Inventory] Stacked {item.itemName} x{existing.count}");
                return;
            }
        }

        items.Add(new ItemStack(item, Mathf.Min(amount, item.stackable ? item.maxStack : 1)));
        Debug.Log($"[Inventory] Added {item.itemName}");
    }

    // Placeholder
    public ItemData GetItem(int index)
    {
        if (index < 0 || index >= items.Count) return null;
        return items[index].data;
    }

    public bool ConsumeOne(int index)
    {
        if (index < 0 || index >= items.Count) return false;
        var stack = items[index];
        stack.count--;
        if (stack.count <= 0) items.RemoveAt(index);
        return true;
    }
}
