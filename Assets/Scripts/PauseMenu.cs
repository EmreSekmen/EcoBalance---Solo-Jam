using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject settingsPanel;
    private bool isPaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null &&
          Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            HandleEscape();
        }





       
    }

    private void HandleEscape()
    {
        if (settingsPanel.activeSelf)
        {
            BackToPauseMenu();
            return;
        }

        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }




    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void SettingsMenu()
    {
        Debug.Log("Settings opened");
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void BackToPauseMenu()
    {
        pauseMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    

}
