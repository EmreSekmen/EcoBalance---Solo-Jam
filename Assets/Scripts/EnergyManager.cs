using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public float EnergyTimer;
    public float Energy = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnergySystem();
    }

    public void EnergySystem()
    {

        if (Energy < 10)
        {
            EnergyTimer += Time.deltaTime;
        }
        else
        {
            EnergyTimer = 0;
        }

        if (EnergyTimer > 3f)
        {
            Energy++;
            EnergyTimer = 0;
        }

    }
}
