using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject currentPauseMenuInstance;
    private static int StartMenuBuildIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }



    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        if (currentPauseMenuInstance)
        {
            Destroy(currentPauseMenuInstance);
        }
        SceneManager.LoadScene(StartMenuBuildIndex); //change to menu scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseButtonClicked()
    {
        if (!gameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
}
