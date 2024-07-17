using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas; 

    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void EndGame()
    {
        gameOverCanvas.SetActive(true); 
        Time.timeScale = 0f;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
