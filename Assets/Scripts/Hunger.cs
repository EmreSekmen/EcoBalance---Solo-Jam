using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public AnimalStat animalStats;
    public float currenHunger { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenHunger = animalStats.maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        currenHunger -= animalStats.hungerDrainRate * Time.deltaTime;
        Dies();
    
    }

    public void Dies()
    {
        if(currenHunger <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Eat()
    {
        currenHunger += animalStats.foodValue;

        if(currenHunger > animalStats.maxHunger * 0.90f)
        {
            currenHunger = animalStats.maxHunger;
        }
    }

    public bool isFull()
    {
        return currenHunger >= animalStats.maxHunger;
    }

}
