using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Campfire : MonoBehaviour
{
    public float range;
    public float rangeDecreaseRate;
    public Transform player;
    public Inventory inventory;
    public StatsManager statsManager;

    public float interactRange;
    public float firewoodIncreaseAmount;

    public Light2D firelight;
    public GameObject fireParticles;

    void Update()
    {
        // Decrease range over time
        range -= rangeDecreaseRate * Time.deltaTime;
        range = Mathf.Clamp(range, 0, 10);
        firelight.pointLightOuterRadius = range;

        if (Vector2.Distance(transform.position, player.position) < range)
        {
            // Player is in range
            statsManager.IncreaseSanity(15);
        }

        if (Vector2.Distance(transform.position, player.position) < interactRange)
        {
            // Player is in range to add more wood to the fire
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Player adds wood (first check if has wood)
                int slotIndex = inventory.HasItem(); // Gets the index of the slot with item in (or -1 if no items)
                if (slotIndex != -1)
                {
                    UseFirewood(slotIndex);
                    Instantiate(fireParticles, transform.position, Quaternion.identity);
                }
            }
        }
    }

    void UseFirewood(int slotIndex)
    {
        range += firewoodIncreaseAmount;
        inventory.UseItem(slotIndex);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
