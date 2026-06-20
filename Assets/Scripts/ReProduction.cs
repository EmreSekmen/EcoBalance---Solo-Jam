using UnityEngine;

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

        Vector3 spawnPos = new Vector3(Random.Range(-4.50f, 4.50f), 0, Random.Range(-2.32f, 2.32f));
        Instantiate(stats.babyPrefab, spawnPos, Quaternion.identity);
        
        
    }

    public void onFoodEaten()
    {
        foodEaten++;

        Debug.Log(gameObject.name + " foodEaten: " + foodEaten);


        if (foodEaten >= stats.foodNeedForReproduction)
        {
            ReProduce();
            foodEaten = 0;
        }
    }
}
