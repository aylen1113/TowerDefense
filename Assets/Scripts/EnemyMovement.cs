using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private int waypointIndex = 0;
    public float speed = 10;
    public float health = 100f;
    public int enemyValue = 10;

    public ParticleSystem deathParticles;



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
        WaveSpawner.EnemiesAlive--;

        // Trigger game over
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.EndGame();
        }

        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathParticles != null)
        Instantiate(deathParticles, transform.position, Quaternion.identity);

        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
        WaveSpawner.totalEnemiesKilled++;
        GameManager.Instance.AddMoney(enemyValue);

    }
}
