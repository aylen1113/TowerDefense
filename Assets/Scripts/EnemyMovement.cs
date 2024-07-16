using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private int waypointIndex = 0;
    public float speed = 10;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPath()
    {
        // Decrease the EnemiesAlive count
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    // Optional: If the enemy takes damage and dies, also decrease the EnemiesAlive count
    public void TakeDamage(float amount)
    {
        // Your logic to reduce health
        // if (health <= 0f) {
        //     Die();
        // }
    }

    void Die()
    {
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
