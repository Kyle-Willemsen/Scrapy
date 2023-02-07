using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplossiveBarrel : MonoBehaviour
{
    public float explosiveRadius;
    public int explosiveDamage;
    public LayerMask damageLayermask;
    public float explosionShake;
    public float explosionShakeTime;
    public GameObject explosion;
    private GameObject explosionClone;
    public float explosionLifetime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            CameraShake.Instance.ShakeCamera(explosionShake, explosionShakeTime);
            ExplosionRadius();
            ExplosionEffect();
            Destroy(gameObject);
        }
    }
    public void ExplosionRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveRadius, damageLayermask);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<EnemyStats>())
            {
                c.GetComponent<EnemyStats>().EnemyTakeDamage(explosiveDamage);
            }

            if (c.GetComponent<PlayerStats>())
            {
                c.GetComponent<PlayerStats>().TakeDamage(explosiveDamage);
            }
        }
    }

    public void ExplosionEffect()
    {
        explosionClone = Instantiate(explosion, transform.position, transform.rotation);
        //explosion.transform.localScale = fullSize;
        Destroy(explosionClone, explosionLifetime);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, explosiveRadius);
    //}
}
