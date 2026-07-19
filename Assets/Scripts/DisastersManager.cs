using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class DisastersManager : MonoBehaviour
{



    private SpawnManager spawnManager;

    public GameObject disastersPanel;

    public Sprite DroughtSprite;
    public Sprite DiseaseSprite;
    public Sprite FıreSprite;

    public Image DisasterIcon;

    public TextMeshProUGUI disasterTitle;
    public TextMeshProUGUI disastersCountdownText;

    public static float reproductionFoodMultiplier = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = FindAnyObjectByType<SpawnManager>();
        StartCoroutine(DisasterLoop());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator DisasterLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);

            float randomValue = Random.value;

            if (randomValue <= 0.30f)
            {
                yield return StartCoroutine(Drought());
            }
            else if (randomValue <= 0.50f)
            {
                yield return StartCoroutine(Disease());
            }
            else if (randomValue <= 0.70f)
            {
                yield return StartCoroutine(Fire());
            }
        }
    }


    IEnumerator Drought()
    {
        disasterTitle.text = "Drought";
        spawnManager.spawnRate = 2f;
        disastersPanel.SetActive(true);
        DisasterIcon.sprite = DroughtSprite;

        float timer = 30f;

        while(timer > 0)
        {
            timer -= Time.deltaTime;
            disastersCountdownText.text = $"{Mathf.CeilToInt(timer)}";
            yield return null;
        }

        disastersPanel.SetActive(false);
        disasterTitle.text = "";
        spawnManager.spawnRate = 0.3f;
    }

    IEnumerator Disease()
    {
        disasterTitle.text = "Disease";
        disastersPanel.SetActive(true);
        DisasterIcon.sprite = DiseaseSprite;
        reproductionFoodMultiplier = 1.5f;

        float timer = 20f;

        while(timer > 0)
        {
            timer -= Time.deltaTime;
            disastersCountdownText.text = $"{Mathf.CeilToInt(timer)}";
            yield return null;
        }

        

        reproductionFoodMultiplier = 1f;
        disastersPanel.SetActive(false);
        disasterTitle.text = "";
    }

    IEnumerator Fire()
    {
        disasterTitle.text = "Wildfire";
        spawnManager.spawnRate = 2f;
        disastersPanel.SetActive(true);
        DisasterIcon.sprite = FıreSprite;

        float timer = 10f;

        while(timer > 0)
        {
            timer -= Time.deltaTime;
            disastersCountdownText.text = $"{Mathf.CeilToInt(timer)}";
            yield return null;
        }

        spawnManager.spawnRate = 1f;

        timer = 15f;

        while(timer > 0)
        {
            timer -= Time.deltaTime;
            disastersCountdownText.text = $"{Mathf.CeilToInt(timer)}";
            yield return null;
        }
       
        disastersPanel.SetActive(false);
        spawnManager.spawnRate = 0.3f;
        disasterTitle.text = "";
    }


}
