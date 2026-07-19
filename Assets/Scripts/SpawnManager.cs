using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class SpawnManager : MonoBehaviour
{
    public float spawnRate = 0.3f;
    public float spawnTimer;


    public GameObject[] EcoPrefabs;

    private EnergyManager energyManager; 
    private AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        energyManager = FindAnyObjectByType<EnergyManager>();
        audioManager = FindAnyObjectByType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {

   

        if(Time.timeScale == 0)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnRate)
        {
            SpawnRandomPrefab();
            spawnTimer = 0;

        }             
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
        Vector3 randomPosition = new Vector3(
       Random.Range(-4.50f, 4.50f),
       10f,
       Random.Range(-2.32f, 2.32f)
   );
        if (NavMesh.SamplePosition(
        randomPosition,
        out NavMeshHit navHit,
        20f,
        NavMesh.AllAreas))
        {
            Instantiate(
                EcoPrefabs[0],
                navHit.position,
                Quaternion.identity
            );
        }
    }
   void SpawnRat()
    {
        Debug.Log("Sol tık algılandı");


        if (energyManager.Energy > 0)
        {
            

            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Raycast vurdu: " + hit.collider.name);

                if (NavMesh.SamplePosition(
                    hit.point,
                    out NavMeshHit navHit,
                    2f,
                    NavMesh.AllAreas))
                {
                    Instantiate(
                        EcoPrefabs[1],
                        navHit.position,
                        Quaternion.identity
                    );
                    audioManager.Play(audioManager.spawnClick);
                    energyManager.Energy -= 1;
                   


                }
                else
                {
                    Debug.LogWarning("Tıklanan noktanın yakınında NavMesh bulunamadı");
                }
            }




        }
    }
    void SpawnFox()
    {
        if(energyManager.Energy > 0)
        {
            

            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Raycast vurdu: " + hit.collider.name);

                if (NavMesh.SamplePosition(
                    hit.point,
                    out NavMeshHit navHit,
                    2f,
                    NavMesh.AllAreas))
                {
                    Instantiate(
                        EcoPrefabs[2],
                        navHit.position,
                        Quaternion.identity
                    );

                    energyManager.Energy -= 1;
                    audioManager.Play(audioManager.spawnClick);
                }
                else
                {
                    Debug.LogWarning("Tıklanan noktanın yakınında NavMesh bulunamadı");
                }
            }
        }

    }


 

 
}
