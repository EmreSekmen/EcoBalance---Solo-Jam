using UnityEngine;
using UnityEngine.AI;

public class FoxAI : MonoBehaviour
{
    private SpawnManager spawnManager;
    private NavMeshAgent agent;
    private Transform target; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnManager = FindAnyObjectByType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            FindClosestRat();
        }
}


    void FindClosestRat()
    {
        GameObject[] EcoPrefabs = GameObject.FindGameObjectsWithTag("Rat");
        float closestDistance = Mathf.Infinity;
        GameObject closestRat = null;

        foreach(GameObject potentialRat in EcoPrefabs)
        {
            float distanceToBitki = Vector3.Distance(transform.position, potentialRat.transform.position);

            if(distanceToBitki < closestDistance)
            {
                closestDistance = distanceToBitki;
                closestRat = potentialRat;

            }
            if(closestRat != null)
            {
                target = closestRat.transform;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rat"))
        {
            Destroy(collision.gameObject);
            GetComponent<Hunger>().Eat();
            GetComponent<ReProduction>().onFoodEaten();
            

        }
    }
}
