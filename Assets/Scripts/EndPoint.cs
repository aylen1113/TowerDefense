using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            WaveSpawner.EnemiesAlive--;

            // Trigger game over
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.EndGame();
            }

            // Destroy the enemy
            Destroy(collision.gameObject);
        }
    }
}
