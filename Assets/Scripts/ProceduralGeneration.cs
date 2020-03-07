using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public float range;

    public GameObject[] spawnItems;

    public float maxItems;

    void Awake()
    {
        Generate();
    }
    
    private void Generate()
    {
        for (int i = 0; i < maxItems; i++)
        {
            Vector3 randomPos = Random.insideUnitCircle * range;
            Instantiate(spawnItems[Random.Range(0, spawnItems.Length)], randomPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
