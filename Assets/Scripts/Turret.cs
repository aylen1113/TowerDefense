using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TowerType towerData;

    private Transform target;

    public Transform partToRotate;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public AudioSource shootAudio;

    void Start()
    {
       
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

   
        if (towerData != null)
        {
            fireCountdown = 1f / towerData.fireRate;
        }
    }

    void Update()
    {
        if (target == null)
            return;


        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion
            .Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * towerData.turnSpeed)
            .eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    
        fireCountdown -= Time.deltaTime;
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / towerData.fireRate;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.damage = towerData.damage; 
            bullet.Seek(target);
        }

        Debug.Log($"{towerData.towerName} fired!");

        shootAudio.Play();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= towerData.range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (towerData == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerData.range);
    }
}
