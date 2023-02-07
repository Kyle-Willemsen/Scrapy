
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifeSpan = 1.75f;
    [SerializeField] int bulletDamage;

    
    private void Awake()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().EnemyTakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        Destroy(gameObject);

       //if (collision.gameObject.tag == "EnemyProjectile")
       //{
       //    Debug.Log("Ignore");
       //    Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
       //}
    }

   //public Vector3 targetPosition;
   //
   //public void Setup(Vector3 targetPosition)
   //{
   //    this.targetPosition = targetPosition;
   //}
   //
   //private void Update()
   //{
   //    float distanceBefore = Vector3.Distance(transform.position, targetPosition);
   //
   //    Vector3 moveDir = (targetPosition - transform.position).normalized;
   //    float moveSpeed = 200f;
   //    transform.position += moveDir * moveSpeed * Time.deltaTime;
   //
   //    float distanceAfter = Vector3.Distance(transform.position, targetPosition);
   //
   //    if (distanceBefore < distanceAfter)
   //    {
   //        Destroy(gameObject);
   //    }
   //}
}
