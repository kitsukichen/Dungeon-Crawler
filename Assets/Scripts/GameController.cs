using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerHealth.OnPlayerDied += GameOverScreen;

        gameOverScreen.SetActive(false);
    }
    void OnDisable()
    {
        // ALWAYS unsubscribe to prevent memory leaks and broken references
        PlayerHealth.OnPlayerDied -= GameOverScreen;
    }

    void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
