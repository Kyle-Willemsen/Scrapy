using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private PlayerStats playerStats;
    public float spinRate;


    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        transform.Rotate(0, spinRate * Time.deltaTime, 0, Space.Self);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HealthPack")
        {
            Destroy(other.gameObject);
            playerStats.playerCurrentHealth += playerStats.healthPackHealth;
            playerStats.healthBar.SetHealth(playerStats.playerCurrentHealth);
        }
    }
}
