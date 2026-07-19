using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI plantsText;
    public TextMeshProUGUI ratCountText;
    public TextMeshProUGUI foxCountText;

    private EnergyManager energyManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        energyManager = FindAnyObjectByType<EnergyManager>();

    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = $"{energyManager.Energy}";
        plantsText.text = $"{GameObject.FindGameObjectsWithTag("Plants").Length}";
        ratCountText.text = $"{GameObject.FindGameObjectsWithTag("Rat").Length}";
        foxCountText.text = $"{GameObject.FindGameObjectsWithTag("Fox").Length}";
    }
}
