using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public HealthBar healthBar;
    public int healthPackHealth;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerCurrentHealth);
    }

    private void Update()
    {
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }

        if (playerCurrentHealth <= 0)
        {
            Destroy(gameObject, 1);
        }
    }

    public void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        healthBar.SetHealth(playerCurrentHealth);
    }

    public void AddHealth(int health)
    {
        playerCurrentHealth += health;
        healthBar.SetHealth(playerCurrentHealth);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HealthPack")
        {
            Destroy(other.gameObject);
            playerCurrentHealth += healthPackHealth;
            healthBar.SetHealth(playerCurrentHealth);
        }
    }
}
