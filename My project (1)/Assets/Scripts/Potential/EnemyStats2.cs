using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats2 : MonoBehaviour
{
    public float currentHealth;
    public float eMaxHealth = 100;
    public int enemyDamage = 20;
    GameObject pStats;
    public bool isShielded;
    private Shield shield;


    public void Start()
    {
        shield = gameObject.GetComponentInChildren<Shield>();
        pStats = GameObject.Find("Player");
        currentHealth = eMaxHealth;
        isShielded = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pStats.GetComponent<PlayerStats>().TakeDamage(enemyDamage);
        }
    }

    public void EnemyTakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void Update()
    {
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }

        if (shield.shieldActive == false)
        {
            isShielded = false;
        }
    }
}
