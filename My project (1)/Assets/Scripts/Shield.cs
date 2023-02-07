using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldHealth;
    public float shieldMaxHealth;
    public int shieldDamage;
    public bool shieldActive = true;
    [SerializeField] MeshRenderer shieldMesh;


    private void Start()
    {
        shieldHealth = shieldMaxHealth;
    }

    public void Update()
    {
        if (shieldHealth <= 0)
        {
            shieldMesh.enabled = false;
            shieldActive = false;
            Destroy(gameObject);
        }
    }
    public void ShieldTakeDamage(int damage)
    {
        shieldHealth -= damage;
    }
}
