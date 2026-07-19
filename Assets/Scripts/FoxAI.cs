using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FoxAI : MonoBehaviour
{
    private SpawnManager spawnManager;
    private NavMeshAgent agent;
    private Transform target;
    private bool CanHunt; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnManager = FindAnyObjectByType<SpawnManager>();
    }

    private void Awake()
    {
        CanHunt = true;
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
                agent.SetDestination(target.position);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {


        if (!CanHunt)
        {
            return;
        }

        MouseAI rat = other.GetComponentInParent<MouseAI>();

        if (rat == null)
            return;


        CanHunt = false;
        Destroy(rat.gameObject);
        

        GetComponent<Hunger>().Eat();
        GetComponent<ReProduction>().onFoodEaten();

        target = null;
        StartCoroutine(HuntCooldown());


    }


    private IEnumerator HuntCooldown()
    {
        
        agent.isStopped = true;

        yield return new WaitForSeconds(0.5f);

        CanHunt = true;
        agent.isStopped = false;
    }
}
