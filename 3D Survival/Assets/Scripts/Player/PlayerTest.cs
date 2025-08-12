using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus)) playerHealth.TakeDamage(10);
        if (Input.GetKeyDown(KeyCode.Equals)) playerHealth.Heal(10);
    }

}
