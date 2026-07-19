
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
public class MouseAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;

    private Hunger hunger;
    private ReProduction reproduction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hunger = GetComponent<Hunger>();
        reproduction = GetComponent<ReProduction>();

        if (reproduction == null)
            Debug.LogError($"{name} üzerinde ReProduction componenti yok!");

    }

    // Update is called once per frame
    void Update()
    {



        if (!agent.isOnNavMesh)
            return;

        if (target == null)
        {
            FindClosestBitki();
        }

    }


    void FindClosestBitki()
    {
        GameObject[] bitkiler = GameObject.FindGameObjectsWithTag("Plants");
        float closestDistance = Mathf.Infinity;
        GameObject closestBitki = null;


        foreach (GameObject potentialBitki in bitkiler)
        {
            float distanceToBitki = Vector3.Distance(transform.position, potentialBitki.transform.position);

            if(distanceToBitki < closestDistance)
            {
                closestDistance = distanceToBitki;
                closestBitki = potentialBitki;
            }

            if (closestBitki != null)
            {
                target = closestBitki.transform;

                if (NavMesh.SamplePosition(
                     target.position,
                    out NavMeshHit navHit,
                    5f,
                   NavMesh.AllAreas))
                {
                    bool destinationAccepted =
                        agent.SetDestination(navHit.position);

                    Debug.Log(
                        $"Bitki bulundu: {target.name} | " +
                        $"Destination kabul edildi: {destinationAccepted}"
                    );
                }
                else
                {
                    Debug.LogWarning(
                        $"Bitkinin yakınında NavMesh bulunamadı: {target.name}"
                    );

                    target = null;
                }


            }

          

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Plants"))
            return;

        Destroy(other.gameObject);

        hunger.Eat();

        if (reproduction != null)
            reproduction.onFoodEaten();

        // Yeni bitki araması için mevcut hedefi bırak.
        target = null;
    }

}
