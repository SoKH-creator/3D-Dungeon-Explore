using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;     // Maximum health value
    public int currentHealth;       // Current health value
    public Slider healthBar;        // Reference to the UI Slider

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Call this method to apply damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    // Call this method to heal
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    // Updates the UI health bar
    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }
}
