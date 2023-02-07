using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public int explosiveBulletDamage;
    public int explosiveDamage;
    public float explosiveRadius;
    public LayerMask enemyLayerMask;
    public GameObject explosion;
    private GameObject explosionClone;
    //public Vector3 startingSize;
    public Vector3 fullSize;
    public float explosionLifetime;
    public float explosionShake;
    public float explosionShakeTime;



    private void OnCollisionEnter(Collision collision)
    {
        ExplosionRadius();
        ExplosionEffect();
        CameraShake.Instance.ShakeCamera(explosionShake, explosionShakeTime);

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().EnemyTakeDamage(explosiveBulletDamage);
            Destroy(gameObject);
            CameraShake.Instance.ShakeCamera(explosionShake, explosionShakeTime);
        }

        Destroy(gameObject);
    }

    public void ExplosionRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveRadius, enemyLayerMask);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<EnemyStats>())
            {
                c.GetComponent<EnemyStats>().EnemyTakeDamage(explosiveDamage);
            }
        }
    }

    public void ExplosionEffect()
    {
        explosionClone = Instantiate(explosion, transform.position, transform.rotation);
        //explosion.transform.localScale = fullSize;
        Destroy(explosionClone, explosionLifetime);
    }
}
