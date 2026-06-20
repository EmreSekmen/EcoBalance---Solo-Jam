using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EcoPrefabs;

    public float EnergyTimer;
    public float Energy = 10;

    public TextMeshProUGUI energyText;
    public TextMeshProUGUI plantsText;
    public TextMeshProUGUI ratCountText;
    public TextMeshProUGUI foxCountText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomPrefab", 2, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = $"Energy: {Energy}";
        ratCountText.text = $"Rats {GameObject.FindGameObjectsWithTag("Rat").Length}";
        foxCountText.text = $"Foxes {GameObject.FindGameObjectsWithTag("Fox").Length}";
        plantsText.text = $" Plants: {GameObject.FindGameObjectsWithTag("Plants").Length}";


        EnergySystem();


        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            SpawnFox();
        }
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            SpawnRat();
        }
    }


    void SpawnRandomPrefab()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-4.50f, 4.50f), 0, Random.Range(-2.32f, 2.32f));
        Instantiate(EcoPrefabs[0], spawnPos, Quaternion.identity);
    }

   void SpawnRat()
    {
        if (Energy > 0)
        {
            Energy -= 1;

            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Vector3 tıklamaNoktası = hit.point;
                Instantiate(EcoPrefabs[1], tıklamaNoktası, Quaternion.identity);
               
            }
            
        }
    }


    void SpawnFox()
    {
        if(Energy > 0)
        {
            Energy -= 1;

            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 tıklamaNoktası = hit.point;
                Instantiate(EcoPrefabs[2], tıklamaNoktası, Quaternion.identity);
                
            }
        }

    }


    public void EnergySystem()
    {
      
        if(Energy < 10)
        {
            EnergyTimer += Time.deltaTime;
        }
        else
        {
            EnergyTimer = 0;
        }

        if(EnergyTimer > 3f)
        {
            Energy++;
            EnergyTimer = 0;
        }

    }

    

  


 
}
