using UnityEngine;

[CreateAssetMenu(fileName = "AnimalStat", menuName = "EcoBalance/AnimalStats")]
public class AnimalStat : ScriptableObject
{
    public float maxHunger = 10f;
    public float hungerDrainRate = 1f;
    public float foodValue = 5f;
    public float moveSpeed = 3f;

    public float ReProduceTime = 10f;
    public GameObject babyPrefab;

    public float foodNeedForReproduction = 5;
    public AnimalType animalType;


    public enum AnimalType
    {
        Rat,
        Fox,
    }

   
}


