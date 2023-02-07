using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifeSpan = 6;
    [SerializeField] int bulletDamage;


    private void Awake()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
