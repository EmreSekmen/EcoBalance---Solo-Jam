using UnityEngine;
using TMPro;

public class SurvivalTimerManager : MonoBehaviour
{
    private float survivalTimer;
    public TextMeshProUGUI survivalTimerText;
    public TextMeshProUGUI SurvivedTimeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        survivalTimer += Time.deltaTime;
        survivalTimerText.text = GetFormattedTime();
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(survivalTimer / 60);
        int seconds = Mathf.FloorToInt(survivalTimer % 60);
        SurvivedTimeText.text = $"{minutes:00} : {seconds:00} ";

        return $"You Survived: {minutes:00}:{seconds:00}";
    }
}
