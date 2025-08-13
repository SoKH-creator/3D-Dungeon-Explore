using UnityEngine;

public enum ItemEffectType
{
    None,
    SpeedBoost,   // move speed for a duration
    Heal,         // HP immediately
    Shield        // temporary shield
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Display")]
    public string itemName;
    [TextArea] public string description;
    public Sprite icon;

    [Header("Effect")]
    public ItemEffectType effectType = ItemEffectType.None;
    public float magnitude = 0f;    // e.g., +speed, +hp
    public float duration = 0f;     // seconds; 0 for instant effects

    [Header("Stack")]
    public bool stackable = true;
    public int maxStack = 99;
}
