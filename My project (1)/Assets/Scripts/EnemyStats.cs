using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public int currentHealth;
    public int eMaxHealth = 100;
    public int enemyDamage = 20;
    GameObject pStats;
    public HealthBar healthbar;

    public GameObject droppableScrap;
    public GameObject droppableHealth;
    [HideInInspector] public GameObject lootTarget;

    public void Start()
    {
        lootTarget = GameObject.FindGameObjectWithTag("LootTarget");
        pStats = GameObject.Find("Character");
        currentHealth = eMaxHealth;
        healthbar.SetMaxHealth(eMaxHealth);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pStats.GetComponent<PlayerStats>().TakeDamage(enemyDamage);
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
            var dropHealth = Instantiate(droppableHealth, transform.position + new Vector3(0, Random.Range(0, 1)), Quaternion.identity);
            var dropScrap = Instantiate(droppableScrap, transform.position + new Vector3(0, Random.Range(0, 1)), Quaternion.identity);
            dropScrap.GetComponent<LootFollow>().target = lootTarget.transform;

        }
    }

    private void LateUpdate()
    {
        healthbar.transform.LookAt(Camera.main.transform);
        healthbar.transform.Rotate(0, 180, 0);
    }



}
