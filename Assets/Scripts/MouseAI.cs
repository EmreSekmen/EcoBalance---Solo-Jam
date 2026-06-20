using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class MouseAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

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
            }

        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plants"))
        {
            Destroy(collision.gameObject);
            GetComponent<Hunger>().Eat();
            GetComponent<ReProduction>().onFoodEaten();
        }
    }

}
