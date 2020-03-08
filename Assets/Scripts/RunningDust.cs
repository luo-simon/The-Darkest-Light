using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDust : MonoBehaviour
{
    public GameObject dustCloudParticle;
    public PlayerMovement playerMovement;

    public float timeDelay;

    private bool instantiatingDust = false;

    void Update()
    {
        if (instantiatingDust == false)
        {
            Debug.Log("1st if");
            if (playerMovement.rb.velocity.magnitude > 0)
                StartCoroutine("InstantiateDust");
        }
    }

    IEnumerator InstantiateDust()
    {
        Debug.Log("dust if");
        instantiatingDust = true;
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        Instantiate(dustCloudParticle, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(timeDelay);
        instantiatingDust = false;
    }
}
