using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlsMenu;

    void Start()
    {
        controlsMenu.SetActive(false);
    }

    public void GameControls()
    {
        controlsMenu.SetActive(true);
    }

    public void ExitButton()
    {
        controlsMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

