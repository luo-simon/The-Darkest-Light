using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public float range;

    public GameObject[] spawnItems;

    public int maxItems;
    private int currentItems;

    public float minDistanceBtwSpawned;

    void Awake()
    {
        currentItems = 0;
        Generate();
    }
    
    private void Generate()
    {
        for (int i = 0; currentItems < maxItems; i++)
        {
            Debug.Log("Trying to generate");
            Vector3 randomPos = Random.insideUnitCircle * range;
            if (CheckSpawnPosition(randomPos) == true) // Checks that the spawn position doesn't already have an object there.
            {
                Instantiate(spawnItems[Random.Range(0, spawnItems.Length)], randomPos, Quaternion.identity);
                currentItems++;
            }
            
        }
    }

    private bool CheckSpawnPosition(Vector3 position)
    {
        // Tweak 2nd parameter to change minimum distance each object can be from each other
        if (Physics2D.OverlapCircle(position, minDistanceBtwSpawned) != null)
            return false;
        else
            return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
