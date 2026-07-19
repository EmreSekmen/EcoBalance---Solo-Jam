using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private float GameOverCountDown;
    public GameObject gameOverPanel;
    public TextMeshProUGUI survivedTimeText;
    public GameObject gameOverAlertPanel;

    private SurvivalTimerManager survivalTimerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        survivalTimerManager = FindAnyObjectByType<SurvivalTimerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        GameOverCountdown();
        GameOver();

    }

    public void GameOverCountdown()
    {


        bool noRats = GameObject.FindGameObjectsWithTag("Rat").Length == 0;
        bool noFoxes = GameObject.FindGameObjectsWithTag("Fox").Length == 0;
        bool noPlants = GameObject.FindGameObjectsWithTag("Plants").Length == 0;

        if (noRats || noFoxes || noPlants)
        {
            GameOverCountDown += Time.deltaTime;
            gameOverAlertPanel.SetActive(true);
        }
        else
        {
            GameOverCountDown = 0;
            gameOverAlertPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (GameOverCountDown > 5)
        {

            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverAlertPanel.SetActive(false);
            survivedTimeText.text = $"You Survived: {survivalTimerManager.GetFormattedTime()}";

        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

   


}
