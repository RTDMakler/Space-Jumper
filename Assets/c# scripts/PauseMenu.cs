using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenu;
    public GameObject DeadMenu;
    [SerializeField] private GameObject optionsMenu;
    public static bool AbleToPause = true;

    private void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Update()
    {
        switch (AbleToPause)
        {
            case true when Input.GetKeyDown(KeyCode.Escape):
            {
                if(GameIsPaused) {Resume(); optionsMenu.SetActive(false);} else Pause();

                break;
            }
            case false:
                DeadMenu.SetActive(true);
                break;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AbleToPause = true;
    }
}
