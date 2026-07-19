using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class ReProduction : MonoBehaviour
{
    public AnimalStat stats;
    private Hunger hunger;

    public float ReProductiontimer;
    private int foodEaten;
    private SpawnManager spawnManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hunger = GetComponent<Hunger>();
        spawnManager = FindAnyObjectByType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger.isFull())
        {
            ReProductiontimer += Time.deltaTime;
        }
        else
        {
            ReProductiontimer = 0;
        }

       


    }


    public void ReProduce()
    {
        Debug.Log("ReProduce fonksiyonuna girildi");

        Vector3 randomOffset = new Vector3(
         Random.Range(-0.5f, 0.5f),
         0f,
         Random.Range(-0.5f, 0.5f)
     );


        Vector3 desiredPosition = transform.position + randomOffset;




        if (NavMesh.SamplePosition(
            desiredPosition,
            out NavMeshHit navHit,
            2f,
            NavMesh.AllAreas))
        {
            Instantiate(
                stats.babyPrefab,
                navHit.position,
                Quaternion.identity
            );

            Debug.Log($"{gameObject.name} reproduced.");
        }
        else
        {
            Debug.LogWarning("Yavru için NavMesh noktası bulunamadı.");
        }


    }


    


    public void onFoodEaten()
    {

        Debug.Log("onFoodEaten çalıştı");

        if (stats == null)
        {
            Debug.LogError("ReProduction içindeki Stats boş!");
            return;
        }

        int requiredFood = Mathf.CeilToInt(stats.foodNeedForReproduction * DisastersManager.reproductionFoodMultiplier);

        Debug.Log($"Food: {foodEaten}/{requiredFood}");

        foodEaten++;

        Debug.Log(gameObject.name + " foodEaten: " + foodEaten);


        if (foodEaten >= requiredFood)
        {
            Debug.Log("Üreme başlıyor");


            ReProduce();
            foodEaten = 0;
        }
    }
}
