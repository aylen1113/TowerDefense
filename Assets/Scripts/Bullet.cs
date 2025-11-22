using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect; // Optional: to show an effect on impact
    public float explosionRadius = 0f; // Set to > 0 for AoE damage
    public float damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        // You can initialize any necessary variables here
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        // Optionally instantiate an impact effect
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject); // Destroy the bullet
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {

        EnemyMovement e = enemy.GetComponent<EnemyMovement>();
        if (e != null)
        {
            e.TakeDamage(50); 
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            HitTarget();
        }
    }
}

